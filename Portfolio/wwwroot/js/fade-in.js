var element = document.querySelector('#fade-in');

element.style.opacity = 0;

void element.offsetWidth; // This forces a browser reflow

element.style.transition = "opacity 0.5s linear";
element.style.opacity = 1;