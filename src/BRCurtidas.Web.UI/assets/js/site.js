    $(window).on("load", function (){
        console.log("documento carregou") 
        $('#exampleModal').on('show.bs.modal', function (event) {
            console.log("modal abriu") 
            var button = $(event.relatedTarget) 
            var productTitle = $(button.data("producttitle")).text()
            var modal = $(this)
            modal.find('.modal-title').text(productTitle)
    })    
})
   