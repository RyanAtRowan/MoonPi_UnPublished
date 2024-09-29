// Select the element with the id "fade-in"
var element = document.querySelector('#fade-in');

// Set the initial opacity of the element to 0 (invisible)
element.style.opacity = 0;

/**
 * Force a reflow by reading the element's layout information (offsetWidth).
 * This ensures that the opacity transition will be applied properly.
 */
void element.offsetWidth;


// Set the transition effect for the element's opacity change (fade-in effect)
element.style.transition = "opacity 0.5s linear";

// Change the opacity to 1, making the element fully visible
element.style.opacity = 1;