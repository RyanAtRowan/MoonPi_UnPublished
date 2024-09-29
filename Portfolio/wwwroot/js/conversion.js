/**
 * Converts the number entered in the input field into a formatted string
 * and updates the displayed value with the formatted result.
 */
function convertNumber() {
    // Get the input value from the field with id "numberInput"
    var input = document.getElementById("numberInput").value;

    // Format the input number using the formatNumber function
    var converted = formatNumber(input);

    // Update the span with id "convertedValue" to show the formatted number
    document.getElementById("convertedValue").innerText = converted;
}

/**
 * Formats a number by converting large values to human-readable strings.
 * Numbers greater than or equal to 1000 are converted with 'k', 'm', or 'b'.
 *
 * @param {number|string} num - The number to be formatted.
 * @returns {string} - A formatted string representing the number.
 */
function formatNumber(num) {
    // Convert the input to a number (in case it's passed as a string)
    num = Number(num);

    // Format numbers larger than or equal to 1 billion
    if (num >= 1000000000) {
        return (num / 1000000000).toFixed(1) + 'b'; // Convert to billions
    }

    // Format numbers larger than or equal to 1 million
    else if (num >= 1000000) {
        return (num / 1000000).toFixed(1) + 'm'; // Convert to millions
    }

    // Format numbers larger than or equal to 1 thousand
    else if (num >= 1000) {
        return (num / 1000).toFixed(1) + 'k'; // Convert to thousands
    }

    // Return the original number if it's less than 1000
    else {
        return num.toString();
    }
}
