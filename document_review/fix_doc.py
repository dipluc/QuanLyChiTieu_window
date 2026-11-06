from zipfile import ZipFile, ZIP_DEFLATED
from lxml import etree as E
from pathlib import Path
src=Path('C:/Users/KhaiDong_F15/Desktop/LTWIN_N05_QLDL.docx'); out=Path('document_review/LTWIN_N05_QLDL_sua_loi_nho.docx')
ns={'w':'http://schemas.openxmlformats.org/wordprocessingml/2006/main'}
z=ZipFile(src); root=E.fromstring(z.read('word/document.xml')); changes=[]
def replace(p,old,new):
 nodes=p.xpath('.//w:t',namespaces=ns); text=''.join(n.text or '' for n in nodes)
 start=text.find(old)
 if start<0:return False
 end=start+len(old); pos=0
 for n in nodes:
  s=n.text or ''; a=pos; b=pos+len(s); pos=b
  if b<=start or a>=end:continue
  n.text=s[:max(0,start-a)]+(new if a<=start<b else '')+s[max(0,end-a):]
  n.set('{http://www.w3.org/XML/1998/namespace}space','preserve')
 changes.append((old,new)); return True
pairs=[('ÚNG DỤNG','ỨNG DỤNG'),('Dăng Ký','Đăng Ký'),('Chuyẻn Tiền','Chuyển Tiền'),('Luồn điều hướng','Luồng điều hướng'),('Kến trúc','Kiến trúc'),('SQL sever','SQL Server'),('cơ sở dũ liệu','cơ sở dữ liệu'),('Desigenr','Designer'),('còn gập','còn gặp'),('26 fom','26 form'),('Mức độc','Mức độ'),('ưu tiêu','ưu tiên'),('cá form','các form'),('đống vai trò','đóng vai trò'),('thực tế hơn.Chúng em','thực tế hơn. Chúng em')]
counts={'list':0,'caption':0}
for p in root.xpath('//w:p',namespaces=ns):
 for old,new in pairs:
  while replace(p,old,new):pass
 text=''.join(p.xpath('.//w:t/text()',namespaces=ns))
 if text.startswith('Hình 1.'):
  import re
  kind='list' if p.xpath('./w:pPr/w:pStyle[@w:val="TOC1"]',namespaces=ns) else 'caption'
  counts[kind]+=1
  replace(p,re.match(r'Hình 1\.\d+',text).group(),f'Hình 3.{counts[kind]}')
assert counts=={'list':26,'caption':26},counts
with ZipFile(out,'w',ZIP_DEFLATED) as dest:
 for item in z.infolist():dest.writestr(__import__('copy').copy(item),E.tostring(root,xml_declaration=True,encoding='UTF-8',standalone=True) if item.filename=='word/document.xml' else z.read(item.filename))
with ZipFile(out) as check:
 assert check.testzip() is None
 assert all(check.read(n)==z.read(n) for n in z.namelist() if n!='word/document.xml')
Path('document_review/change_log.txt').write_text('\n'.join(f'{a} → {b}' for a,b in changes),encoding='utf-8')
print(out.resolve());print('Edits:',len(changes),'Figures:',counts,'All other package parts unchanged')

