const buttons = document.querySelectorAll('.brandchooser button');

buttons.forEach(button => {
    button.addEventListener('click', function () {
        const brand = this.getAttribute('data-type');
        filterProducts(brand);
    });
});

function filterProducts(brand) {
    const products = document.query
}