import json,html
from pathlib import Path
s=json.loads(Path('document_review/erd_schema.json').read_text(encoding='utf-8-sig'))
out=Path('document_review/ERD');out.mkdir(exist_ok=True)
tables={t:[c for c in s['columns'] if c['table_name']==t] for t in dict.fromkeys(c['table_name'] for c in s['columns'])}
fks={(f['child_table'],f['child_column']) for f in s['foreign_keys']}
unique={(c['table_name'],c['column_name']) for c in s['unique_columns']}
def typ(c):
 t=c['data_type']
 if t in ('nvarchar','varchar','char','nchar'):t+=f"({int(c['max_length'])//(2 if t.startswith('n') else 1) if int(c['max_length'])>0 else 'max'})"
 if t in ('decimal','numeric'):t+=f"({c['precision']},{c['scale']})"
 return t
m=['erDiagram','    direction LR']
for t,cols in tables.items():
 m.append(f'    {t} {{')
 for c in cols:
  k=[]
  if c['is_pk']:k.append('PK')
  if (t,c['column_name']) in fks:k.append('FK')
  m.append(f"        {typ(c).replace(',','_')} {c['column_name']} {','.join(k)}".rstrip())
 m.append('    }')
for f in s['foreign_keys']:
 c=next(c for c in tables[f['child_table']] if c['column_name']==f['child_column'])
 left='|o' if c['is_nullable'] else '||'
 right='o|' if (f['child_table'],f['child_column']) in unique else 'o{'
 m.append(f"    {f['parent_table']} {left}--{right} {f['child_table']} : {f['child_column']}")
(out/'ERD_QLChiTieu.mmd').write_text('\n'.join(m),encoding='utf-8')
for compact in (False,True):
 lines=['digraph ERD {','graph [rankdir=LR, bgcolor="white", pad=0.35, nodesep=0.65, ranksep=1.5, splines=polyline, outputorder=edgesfirst, fontname="Arial", label="ERD — QUẢN LÝ CHI TIÊU CÁ NHÂN\\n12 bảng • 22 khóa ngoại | PK: khóa chính · FK: khóa ngoại · ?: cho phép NULL\\nĐọc mỗi đường: phía bảng cha → phía bảng con (0..N hoặc 0..1)", labelloc=t, fontsize=23];','node [shape=plain,fontname="Arial"];','edge [fontname="Arial",fontsize=11,arrowsize=0.7,color="#526477",fontcolor="#30445c"];']
 for t,cols in tables.items():
  rows=[f'<TR><TD COLSPAN="3" BGCOLOR="#173954"><FONT COLOR="white"><B>{t}</B></FONT></TD></TR>']
  for c in cols:
   key=[]
   if c['is_pk']:key.append('PK')
   if (t,c['column_name']) in fks:key.append('FK')
   if compact and not key:continue
   name=c['column_name']; null=' ?' if c['is_nullable'] else ''
   rows.append(f'<TR><TD ALIGN="LEFT">{" / ".join(key)}</TD><TD PORT="{name}" ALIGN="LEFT"><B>{name}</B>{null}</TD><TD ALIGN="LEFT">{html.escape(typ(c))}</TD></TR>')
  lines.append(f'{t} [label=<<TABLE BORDER="0" CELLBORDER="1" CELLSPACING="0" CELLPADDING="7" COLOR="#cbd5df">'+''.join(rows)+'</TABLE>>];')
 for f in s['foreign_keys']:
  child=f['child_table']; col=f['child_column']; parent=f['parent_table']; pc=f['parent_column']
  c=next(c for c in tables[child] if c['column_name']==col)
  pcard='0..1' if c['is_nullable'] else '1'
  ccard='0..1' if (child,col) in unique else '0..N'
  color='#2177b6' if parent=='NguoiDung' else '#526477'
  lines.append(f'{parent}:{pc}:e -> {child}:{col}:w [dir=both,arrowtail=none,arrowhead=none,taillabel="{pcard}",headlabel="{ccard}",labeldistance=2.2,color="{color}",tooltip="{parent}.{pc} → {child}.{col}"];')
 lines.append('}')
 (out/('ERD_khoa.dot' if compact else 'ERD_day_du.dot')).write_text('\n'.join(lines),encoding='utf-8')
print('Created DOT and Mermaid from catalog metadata')
