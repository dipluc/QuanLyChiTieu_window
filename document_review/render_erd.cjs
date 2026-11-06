const fs = require('fs');
const base='C:/Users/KhaiDong_F15/.cache/codex-runtimes/codex-primary-runtime/dependencies/node/node_modules/';
const {instance}=require(base+'@viz-js/viz');
const sharp=require(base+'sharp');
(async()=>{const viz=await instance();for(const name of ['ERD_day_du','ERD_khoa']){const svg=viz.renderString(fs.readFileSync('document_review/ERD/'+name+'.dot','utf8'),{format:'svg'});fs.writeFileSync('document_review/ERD/'+name+'.svg',svg);await sharp(Buffer.from(svg),{density:160}).png().toFile('document_review/ERD/'+name+'.png');console.log(name,await sharp('document_review/ERD/'+name+'.png').metadata());}})().catch(e=>{console.error(e);process.exit(1)});
