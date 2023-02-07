const idcard=document.getElementById('idCard');
const firstButton=document.getElementById('main_button');
const bookcard=document.querySelector('.second_card');
const follcard=document.querySelector('.third_card');
const quecard=document.querySelector('.fourth_card');
firstButton.onclick =function (){
    firstButton.classList.toggle('fade');
    idcard.classList.toggle('activate');
    bookcard.classList.toggle('activate');
    follcard.classList.toggle('activate');
    quecard.classList.toggle('activate');
};


