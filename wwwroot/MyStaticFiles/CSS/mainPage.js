const track = document.querySelector('.carousel_track');
const slides = Array.from(track.children);
const nextButton = document.querySelector('.carousel_button--right');
const prevButton = document.querySelector('.carousel_button--left');


const slideWidth = slides[0].getBoundingClientRect().width;

//arrange the slides next to each other
const setSlidePosition=(slide,index) => {
    slide.style.left = slideWidth * index + 'px';
};
slides.forEach(setSlidePosition);

const moveToSlide = (track, currentSlide,targetSlide)  => {
    track.style.transform = 'translateX(-'+targetSlide.style.left+')';
    currentSlide.classList.remove('current-slide');
    targetSlide.classList.add('current-slide');
}

prevButton.addEventListener('click',e =>{
    const currentSlide=track.querySelector('.current-slide');
    const prevSlide = currentSlide.previousElementSibling;
    moveToSlide(track,currentSlide,prevSlide);
});

//when i click left/right move the slide respectively
nextButton.addEventListener('click',e => {
    const currentSlide=track.querySelector('.current-slide');
    const nextSlide = currentSlide.nextElementSibling;
    //move to the next slide
    moveToSlide(track,currentSlide,nextSlide);

});