/// <reference path="jquery-3.3.1.min.js" />
var cart = {
    // init: function () {
    //     cart.regEvents();
    // },
    regEvents: function () {
        
        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/Home";
        });
        $('#btnBayment').off('click').on('click', function(e){
            e.preventDefault();
            window.location.href = "/Cart/Paymen";
        });
        $("#btnUpdateAll").off('click').on('click',function(e){
            e.preventDefault();
            var ListProduct = $('.quality_buy');
            var ItemCart = [];
            $.each(ListProduct,function(i,v){
                ItemCart.push({
                    Quantity : $(v).val(),
                    Product : {
                        Id: $(v).data('id')
                    }
                });
            });
            if (ItemCart != null) {
                $.ajax({
                    url: '/Cart/UpdateAll',
                    data: { CartModel: JSON.stringify(ItemCart) },
                    dataType: "json",
                    type: "POST",
                    success: function (ref) {
                        if (ref.status) {
                            window.location.href = "/Cart/ListCart";
                        }

                    }
                })
            }
           

        })
        $("#btnDeleteAll").off('click').on('click',function(e){
            e.preventDefault();
            $.ajax({
                url:'/Cart/DeleteAll',
                dataType:"json",
                type:"POST",
                success: function (ref) {
                    if (ref.status == true) {

                        window.location.href = "/Cart/ListCart";
                    }
                }
            })
        })
        $("#btnDeleteId").off('click').on('click',function(e){
            e.preventDefault();
            $.ajax({
                data: {id: $(this).data('id')},
                url:"/Cart/DeleteId",
                dataType:"json",
                type:"POST",
                success: function(ref){
                    if(ref.status){
                        window.location.href = "/Cart/ListCart";
                    }
                }
            });
        })
        
    } 
}
cart.regEvents();