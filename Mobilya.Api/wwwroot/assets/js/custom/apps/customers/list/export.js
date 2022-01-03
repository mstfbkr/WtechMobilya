"use strict"; var KTCustomersExport = function () {
    var t, e, n, o, r, i, a; return {
        init: function () {
            t = document.querySelector("#kt_customers_export_modal"),
                a = new bootstrap.Modal(t),
                i = document.querySelector("#kt_customers_export_form"),
                e = i.querySelector("#kt_customers_export_submit"),
                n = i.querySelector("#kt_customers_export_cancel"),
                o = t.querySelector("#kt_customers_export_close"),
                r = FormValidation.formValidation(i, { 
                    fields: {
                        date:
                        {
                            validators: {
                                notEmpty:
                                {
                                    message: "Date range is required"
                                }
                            }
                        }
                    }, plugins: {
                        trigger: new FormValidation.plugins.Trigger,
                        bootstrap: new FormValidation.plugins.Bootstrap5({
                            rowSelector: ".fv-row",
                            eleInvalidClass: "",
                            eleValidClass: ""
                        })
                    }
                }), e.addEventListener("click", (function (t) {
                t.preventDefault(),
                    r && r.validate().then((function (t) {
                        console.log("validated!"),
                            "Valid" == t ? (
                            e.setAttribute(
                                "data-kt-indicator",
                                "on"),
                            e.disabled = !0, setTimeout((function () {
                        e.removeAttribute("data-kt-indicator"),
                            Swal.fire({
                                text: "Customer list has been successfully exported!",
                                icon: "success", buttonsStyling: !1,
                                confirmButtonText: "Ok, got it!",
                                customClass: {
                                    confirmButton: "btn btn-primary"

                                   
                                }

                            }).then((function (t) {
                                t.isConfirmed && (a.hide(),
                                    e.disabled = !1)
                            })) //Excel Convert

                                var preHtml = "<html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'><head><meta charset='utf-8'><title>Döküman Çýktýsý</title><link href='" + cssUrl + "' rel='stylesheet'/>"

                                if (margins == null || margins == undefined)
                                    margins = '0.2cm 0.8cm 0cm 0.2cm';
                                var styles = '<style>\n' +
                                    '@page\n' +
                                    '{\n' +
                                    '    size:21cm 29.7cmt;  /* A4 */\n' +
                                    '    margin:' + margins + '; \n' +
                                    '    mso-page-orientation: portrait;  \n' +
                                    '   \n' +
                                    '}\n' +
                                    '@page a4 { }\n' +
                                    'div.a4 { page:a4; }\n' +
                                    'p.MsoHeader, p.MsoFooter { border: 1px solid black; }\n' +
                                    '</style>\n';

                                var closeHead = "</head > <body>";
                                var postHtml = "</body></html>";
                                var el = document.getElementById(element);
                                debugger;
                                var html = preHtml + styles + closeHead + el.outerHTML + postHtml;

                                var blob = new Blob(['\ufeff', html], {
                                    type: 'application/msword'
                                });

                                var url = 'data:application/vnd.ms-word;charset=utf-8,' + encodeURIComponent(html);

                                // Specify file name
                                var filename = reportName + '.doc';

                                // Create download link element
                                var downloadLink = document.createElement("a");

                                document.body.appendChild(downloadLink);

                                if (navigator.msSaveOrOpenBlob) {
                                    navigator.msSaveOrOpenBlob(blob, filename);
                                } else {
                                    // Create a link to the file
                                    downloadLink.href = url;

                                    // Setting the file name
                                    downloadLink.download = filename;

                                    //triggering the function
                                    downloadLink.click();
                                }

                                document.body.removeChild(downloadLink);
                    }), 2e3)) :
                        Swal.fire({
                            text: "Sorry, looks like there are some errors detected, please try again.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: { confirmButton: "btn btn-primary" }
                        })
                }))
                })), n.addEventListener("click", (function (t) {
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
                            t.value ? (i.reset(),
                                a.hide()) : "cancel" === t.dismiss && Swal.fire({
                                    text: "Your form has not been cancelled!.",
                                    icon: "error",
                                    buttonsStyling: !1,
                                    confirmButtonText: "Ok, got it!",
                                    customClass: { confirmButton: "btn btn-primary" }
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
                            t.value ? (i.reset(), a.hide()) : "cancel" === t.dismiss && Swal.fire({
                                text: "Your form has not been cancelled!.",
                                icon: "error",
                                buttonsStyling: !1,
                                confirmButtonText: "Ok, got it!",
                                customClass: { confirmButton: "btn btn-primary" }
                            })
                        }))
                })), function () {
                    const t = i.querySelector("[name=date]"); $(t).flatpickr({
                        altInput: !0,
                        altFormat: "F j, Y",
                        dateFormat: "Y-m-d",
                        mode: "range"
                    })
                }()
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTCustomersExport.init() }));