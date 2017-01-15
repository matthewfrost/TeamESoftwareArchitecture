var ViewModel;
var Thamco = $.extend(true, {}, Thamco, {
    Views: {
        Cart: {
            Init: function () {
                ViewModel = new Thamco.ViewModel.Cart();
                ViewModel.getCookies(ViewModel.getBoxSuccess);
                ViewModel.getWrappings(ViewModel.getWrappingsSuccess, ViewModel.getWrappingsError);
                ko.applyBindings(ViewModel);
            }  
        }
    }
});

$(function () {
    Thamco.Views.Cart.Init();
});