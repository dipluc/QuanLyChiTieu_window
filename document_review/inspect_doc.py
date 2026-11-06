from docx import Document
p='C:/Users/KhaiDong_F15/Desktop/LTWIN_N05_QLDL.docx'
d=Document(p)
with open('document_review/inspection.txt','w',encoding='utf-8') as f:
 for i,p in enumerate(d.paragraphs):
  if p.text.strip(): f.write(f'{i}\t{p.style.name}\t{p.text}\n')
 f.write('\nSECTIONS\n')
 for i,s in enumerate(d.sections):
  f.write(f'{i} header={s.header.paragraphs[0].text!r} footer={[p.text for p in s.footer.paragraphs]}\n')
print('paragraphs',len(d.paragraphs),'tables',len(d.tables),'sections',len(d.sections))
