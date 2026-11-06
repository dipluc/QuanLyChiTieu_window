$erdConn = New-Object System.Data.SqlClient.SqlConnection 'Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Connect Timeout=15'
$erdConn.Open()
$cmd=$erdConn.CreateCommand()
$cmd.CommandText="SELECT DB_NAME(database_id) FROM sys.master_files WHERE physical_name = N'D:\Nhom5_test2\LTWIN_N05_QLCT\Database\QLChiTieu.mdf'"
$db=[string]$cmd.ExecuteScalar()
if (!$db) {throw 'Database not found'}
$erdConn.ChangeDatabase($db)
$queries=@{
 columns="SELECT t.name AS table_name,c.name AS column_name,ty.name AS data_type,c.max_length,c.precision,c.scale,c.is_nullable, CASE WHEN pk.column_id IS NULL THEN 0 ELSE 1 END AS is_pk FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id JOIN sys.types ty ON c.user_type_id=ty.user_type_id LEFT JOIN (SELECT ic.object_id,ic.column_id FROM sys.indexes i JOIN sys.index_columns ic ON ic.object_id=i.object_id AND ic.index_id=i.index_id WHERE i.is_primary_key=1) pk ON pk.object_id=c.object_id AND pk.column_id=c.column_id WHERE t.is_ms_shipped=0 ORDER BY t.name,c.column_id"
 foreign_keys="SELECT fk.name,OBJECT_NAME(fkc.parent_object_id) AS child_table,COL_NAME(fkc.parent_object_id,fkc.parent_column_id) AS child_column,OBJECT_NAME(fkc.referenced_object_id) AS parent_table,COL_NAME(fkc.referenced_object_id,fkc.referenced_column_id) AS parent_column FROM sys.foreign_keys fk JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id=fk.object_id ORDER BY child_table,child_column"
 unique_columns="SELECT t.name AS table_name,c.name AS column_name FROM sys.indexes i JOIN sys.tables t ON t.object_id=i.object_id JOIN sys.index_columns ic ON ic.object_id=i.object_id AND ic.index_id=i.index_id JOIN sys.columns c ON c.object_id=ic.object_id AND c.column_id=ic.column_id WHERE i.is_unique=1 AND (SELECT COUNT(*) FROM sys.index_columns j WHERE j.object_id=i.object_id AND j.index_id=i.index_id AND j.key_ordinal>0)=1"
}
$result=@{}
foreach($key in $queries.Keys){$cmd=$erdConn.CreateCommand();$cmd.CommandText=$queries[$key];$dt=New-Object System.Data.DataTable;$dt.Load($cmd.ExecuteReader());$rows=@(foreach($row in $dt.Rows){$obj=@{};foreach($col in $dt.Columns){$obj[$col.ColumnName]=$row[$col.ColumnName]};$obj});$result[$key]=$rows}
$result | ConvertTo-Json -Depth 8 | Set-Content -Encoding utf8 'D:/Nhom5_test2/document_review/erd_schema.json'
$erdConn.Close()
Write-Output ('Tables: '+(($result.columns.table_name | Select-Object -Unique).Count)+'; Foreign keys: '+$result.foreign_keys.Count)
