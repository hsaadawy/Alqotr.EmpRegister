window.printDivToPdf = function (divId) {
    debugger
    var element = document.getElementById(divId);
    html2pdf(element, {
        margin: 1,
        filename: 'document.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    });
};
