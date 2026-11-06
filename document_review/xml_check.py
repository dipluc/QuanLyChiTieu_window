from zipfile import ZipFile
from lxml import etree as E
z=ZipFile('C:/Users/KhaiDong_F15/Desktop/LTWIN_N05_QLDL.docx'); ns={'w':'http://schemas.openxmlformats.org/wordprocessingml/2006/main'}
r=E.fromstring(z.read('word/document.xml'))
for p in r.xpath('//w:p',namespaces=ns):
 t=''.join(p.xpath('.//w:t/text()',namespaces=ns))
 if t.startswith('Hình 1.1 '):print(E.tostring(p,encoding='unicode')[:3500])
