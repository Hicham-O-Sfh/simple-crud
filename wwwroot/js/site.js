$(
    function () {
        // enable ToolTips
        // docs : https://getbootstrap.com/docs/5.1/components/tooltips/#example-enable-tooltips-everywhere
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })

        // buttons that triggers CRUD Modals
        $("#btn-modal-add").click(function () {
            // retrieve the URL from the button's "data-url" attribute 
            let url = $(this).data("url");

            // get the "modal-ajout-etudiant" from BackEnd using ajax
            $.get(url).done(function (result) {
                // inject the incoming modal
                $("#modal").html(result);

                // trigger "show" event to open the Modal
                $("#modal-ajout-etudiant").modal("show");

                // trigger and refresh jquery validation
                // for the new injected inputs
                refreshValidation();
            });
        });

        $(".btn-modal-edit").click(function () {
            // retrieve the URL from the button's "data-url" attribute 
            // and decode it because it's encoded by default (contains '%F1' instead of '/')
            let url = decodeURIComponent($(this).data("url"));

            $.get(url).done(function (result) {
                $("#modal").html(result);
                $("#modal-edit-etudiant").modal("show");
                refreshValidation();
            });
        });

        $(".btn-modal-delete").click(function () {
            let url = decodeURIComponent($(this).data("url"));
            $.get(url).done(function (result) {
                $("#modal").html(result);
                $("#modal-ajout-delete").modal("show");
            });
        });

        $(".btn-exclusion").click(function () {
            let url = decodeURIComponent($(this).data("url"));
            let $btn = $(this);
            let is_excluded = $btn.attr("data-is-excluded") == "true";

            // status is the returned value from the controller's action after calling it 
            // using Js AJAX
            $.get(url).done(function (status) {
                // using the notify.js library to display an alert message on top right of the page
                $.notify(
                    "l'étudiant est : " + (status ? "exclut" : "inclut"), // message to display
                    "success" // bootstrap class
                );
                $btn.attr("data-is-excluded", !(is_excluded));
                $btn.html(
                    !is_excluded ?
                        `<i class="bi bi-shield-fill-check"></i>` :
                        `<i class="bi bi-shield-x"></i>`
                )
            })
        })

        // reusable function for refreshing jquery validation 
        function refreshValidation() {
            var $form = $("form")
            $form
                .removeData('validator')
                .removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse($form);
        }

        // initialize & enable the DataTable
        $('#table-des-etudiants').DataTable({
            language: {
                processing: "Traitement en cours...",
                search: "Rechercher&nbsp;:",
                lengthMenu: "Afficher _MENU_ &eacute;l&eacute;ments",
                info: "Affichage de l'&eacute;lement _START_ &agrave; _END_ sur _TOTAL_ &eacute;l&eacute;ments",
                infoEmpty: "Affichage de l'&eacute;lement 0 &agrave; 0 sur 0 &eacute;l&eacute;ments",
                infoFiltered: "(filtr&eacute; de _MAX_ &eacute;l&eacute;ments au total)",
                infoPostFix: "",
                loadingRecords: "Chargement en cours...",
                zeroRecords: "Aucun &eacute;l&eacute;ment &agrave; afficher",
                emptyTable: "Aucune donnée disponible dans le tableau",
                paginate: {
                    first: "Premier",
                    previous: "Pr&eacute;c&eacute;dent",
                    next: "Suivant",
                    last: "Dernier"
                },
            }
        });
    }
);