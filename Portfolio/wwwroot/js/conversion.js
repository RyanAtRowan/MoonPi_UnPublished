function convertNumber() {
    var input = document.getElementById("numberInput").value;
    var converted = formatNumber(input);
    document.getElementById("convertedValue").innerText = converted;
}

function formatNumber(num) {
    num = Number(num);
    if (num >= 1000000000) {
        return (num / 1000000000).toFixed(1) + 'b';
    }

    else if (num >= 1000000) {
        return (num / 1000000).toFixed(1) + 'm';
    }

    else if (num >= 1000) {
        return (num / 1000).toFixed(1) + 'k';
    } else {
        return num.toString();
    }
}
