let btn=document.querySelector('#btn');
let sidebar=document.querySelector('.sidebar');
btn.onclick = function (){
    sidebar.classList.toggle('active');
};
const accordionItemHeaders=document.querySelectorAll('.accordion-item-header');
accordionItemHeaders.forEach(accordionItemHeaders =>{
    accordionItemHeaders.addEventListener('click',event => {
        accordionItemHeaders.classList.toggle('active2');
    });
});
