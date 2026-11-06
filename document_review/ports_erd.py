from pathlib import Path
import re
for p in Path('document_review/ERD').glob('*.dot'):
 s=p.read_text(encoding='utf8')
 s=re.sub(r'<TR><TD ALIGN="LEFT">([^<]*)</TD><TD PORT="([^"]+)" ALIGN="LEFT">(.*?)</TD><TD ALIGN="LEFT">(.*?)</TD></TR>',lambda m:f'<TR><TD PORT="{m[2]}_in" ALIGN="LEFT">{m[1]}</TD><TD ALIGN="LEFT">{m[3]}</TD><TD PORT="{m[2]}_out" ALIGN="LEFT">{m[4]}</TD></TR>',s)
 s=re.sub(r':(\w+):e -> (\w+):(\w+):w',r':\1_out:e -> \2:\3_in:w',s)
 p.write_text(s,encoding='utf8')
