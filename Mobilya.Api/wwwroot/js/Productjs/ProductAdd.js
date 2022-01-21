"use strict";
var KTModalCustomersAdd = function () {
    var t, e, o, n, r, i, theContact,productId;

    
    function convertUTCDateToLocalDate(date) {
        var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);
        var offset = date.getTimezoneOffset() / 60;
        var hours = date.getHours();
        newDate.setHours(hours - offset);
        return newDate;
    }


    return {
        init: function () {
            i = new bootstrap.Modal(document.querySelector("#kt_modal_add_customer")),
                r = document.querySelector("#kt_modal_add_customer_form"),
                t = r.querySelector("#kt_modal_add_customer_submit"),
                e = r.querySelector("#kt_modal_add_customer_cancel"),
                o = r.querySelector("#kt_modal_add_customer_close"),
                n = FormValidation.formValidation(r,
                    {
                        fields: {
                            productname: {
                                validators: {
                                    notEmpty: {
                                        message: "Product name is required"
                                    }
                                }
                            },
                            productprice: {
                                validators: {
                                    notEmpty: {
                                        message: "Product Price is required"
                                    }
                                }
                            },
                            plugins: {
                                trigger: new FormValidation.plugins.Trigger,
                                bootstrap: new FormValidation.plugins.Bootstrap5({
                                    rowSelector: ".fv-row",
                                    eleInvalidClass: "",
                                    eleValidClass: ""
                                })
                            }
                        }

                    });

            $(r.querySelector('[name=""]')).on("change",
                (function () { n.revalidateField("country") })),
                t.addEventListener("click",
                    (function (e) {
                        e.preventDefault(), n && n.validate().then((
                            function (e) {
                                console.log("validated!"),
                                    "Valid" == e ? (t.setAttribute("data-kt-indicator", "on"),
                                        t.disabled = !0,
                                        setTimeout((function () {
                                            if ($("[name='productId']").val() == "0") {
                                                productId = 0;
                                            } else {
                                                productId = parseInt($("[name='productId']").val())
                                            }
                                            t.removeAttribute("data-kt-indicator"),
                                                t.disabled = !1,
                                               
                                            theContact = {
                                                     ProductId: productId,
                                                    ProductName: $("[name='productname']").val(),
                                                    ProductDescription: $("[name='productdescription']").val(),
                                                    ProductPrice: $("[name='productprice']").val(),
                                                    //CreatingDate: convertUTCDateToLocalDate(new Date(Date.now())),
                                                    //UpdatedDate: convertUTCDateToLocalDate(new Date(Date.now())),
                                                    CategoryId: $("[name='categoryıd']").val(),
                                                    IsActived:"true"
                                                };
                                            console.log(JSON.stringify(theContact));
                                            $.ajax({
                                                type: "POST",
                                                url: "https://localhost:44375/api/Product/Create",
                                                dataType: "json",
                                                contentType: "application/json; charset=utf-8",
                                                data: JSON.stringify(theContact),                                                
                                                success: function (data) {
                                                    Swal.fire({
                                                        text: "İşlem başarılı şeklide yapıldı",
                                                        icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!",
                                                        customClass: { confirmButton: "btn btn-primary" }
                                                    }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))
                                                },
                                                error: function (data) {
                                                    Swal.fire({
                                                        text: "Hata Sistem yöneticisi ile iletişime geçiniz!",
                                                        icon: "Hata", buttonsStyling: !1, confirmButtonText: "Ok, got it!",
                                                        customClass: { confirmButton: "btn btn-primary" }
                                                    }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))

                                                }

                                            });


                                            //t.removeAttribute("data-kt-indicator"),
                                            //    Swal.fire({
                                            //        text: "Form has been successfully submitted!",
                                            //        icon: "success",
                                            //        buttonsStyling: !1,
                                            //        confirmButtonText: "Ok, got it!",
                                            //        customClass: {
                                            //        confirmButton: "btn btn-primary"
                                            //        }
                                            //    }).then((function (e) {
                                            //        e.isConfirmed && (i.hide(),
                                            //            t.disabled = !1,
                                            //            window.location = r.getAttribute("data-kt-redirect"))
                                            //    }))
                                        }), 2e3)) : Swal.fire({
                                            text: "Sorry, looks like there are some errors detected, please try again.",
                                            icon: "error",
                                            buttonsStyling: !1,
                                            confirmButtonText: "Ok, got it!",
                                            customClass: {
                                                confirmButton: "btn btn-primary"
                                            }
                                        })
                            }))
                    })), e.addEventListener("click",
                        (function (t) {
                            t.preventDefault(),
                                Swal.fire({
                                    text: "Are you sure you would like to cancel?",
                                    icon: "warning", showCancelButton: !0,
                                    buttonsStyling: !1, confirmButtonText:
                                        "Yes, cancel it!",
                                    cancelButtonText: "No, return",
                                    customClass: {
                                        confirmButton: "btn btn-primary",
                                        cancelButton: "btn btn-active-light"
                                    }
                                }).then((function (t) {
                                    t.value ? (r.reset(),
                                        i.hide()) : "cancel" === t.dismiss && Swal.fire({
                                            text: "Your form has not been cancelled!.",
                                            icon: "error",
                                            buttonsStyling: !1,
                                            confirmButtonText: "Ok, got it!",
                                            customClass: {
                                                confirmButton: "btn btn-primary"
                                            }
                                        })
                                }))
                        })), o.addEventListener("click", (function (t) {
                            t.preventDefault(),
                                Swal.fire({
                                    text: "Are you sure you would like to cancel?",
                                    icon: "warning",
                                    showCancelButton: !0,
                                    buttonsStyling: !1,
                                    confirmButtonText: "Yes, cancel it!",
                                    cancelButtonText: "No, return",
                                    customClass: {
                                        confirmButton: "btn btn-primary",
                                        cancelButton: "btn btn-active-light"
                                    }
                                }).then((function (t) {
                                    t.value ? (r.reset(),
                                        i.hide()) : "cancel" === t.dismiss && Swal.fire({
                                            text: "Your form has not been cancelled!.",
                                            icon: "error",
                                            buttonsStyling: !1,
                                            confirmButtonText: "Ok, got it!",
                                            customClass: {
                                                confirmButton: "btn btn-primary"
                                            }
                                        })
                                }))
                        }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTModalCustomersAdd.init() }));