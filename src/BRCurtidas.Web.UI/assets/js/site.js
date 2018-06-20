    $(window).on("load", function (){
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) 
            var productTitle = $(button.data("producttitle")).text()
            var modal = $(this)
            modal.find('.modal-title').text(productTitle)

            let priceConst = parseFloat(button.data("price").replace(",", "."));
            let userQtd = parseFloat(getQuantityItem())
            let result = calcular(priceConst, userQtd)

            upDateModalPrice($('#valor_manual'), result)

            $('#quantity_item').on('blur', () => {                       
                let userQtd = parseFloat(getQuantityItem())
                let result = calcular(priceConst, userQtd)
    
                upDateModalPrice($('#valor_manual'), result)
            });
    })
})

let calcular = function (price, quantity){
    return (price * quantity).toFixed(2)
}

let upDateModalPrice = function(element, valor) {
    element.text('Total: R$ ' + valor.replace(".", ","))
}

let getQuantityItem = function() {
    let value = $('#quantity_item').val()
    if (value == undefined)
        value = 1
    return value    
}