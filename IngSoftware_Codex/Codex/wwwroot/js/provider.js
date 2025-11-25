document.addEventListener("DOMContentLoaded", function () {

    console.log("DOM cargado, inicializando...");

    // -------------------------
    // MODAL DE EDITAR / ELIMINAR
    // -------------------------
    let formToSubmit = null;

    const modal = document.getElementById("confirmModal");
    const modalMessage = document.getElementById("modalMessage");
    const btnYes = document.getElementById("btnYes");
    const btnNo = document.getElementById("btnNo");

    // Confirmación de guardar
    document.querySelectorAll(".confirm-save").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            formToSubmit = this.closest("form");
            modalMessage.textContent = "¿Deseas guardar los cambios?";
            modal.style.display = "flex";
        });
    });

    // Confirmación de eliminar
    document.querySelectorAll(".confirm-delete").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            formToSubmit = this.closest("form");
            modalMessage.textContent = "¿Seguro que deseas eliminar este computador?";
            modal.style.display = "flex";
        });
    });

    // Botón Aceptar en modal
    btnYes.addEventListener("click", function () {
        if (formToSubmit) formToSubmit.submit();
        modal.style.display = "none";
        formToSubmit = null;
    });

    // Botón Cancelar en modal
    btnNo.addEventListener("click", function () {
        modal.style.display = "none";
        formToSubmit = null;
    });

    // -------------------------
    // BUSCADOR
    // -------------------------
    const searchInput = document.getElementById("searchInput");
    const rows = document.querySelectorAll("tbody tr");

    searchInput.addEventListener("input", function () {
        const value = this.value.toLowerCase().trim();

        rows.forEach(row => {
            const brandCell = row.querySelector('input[name="Brand"]');
            row.style.display = brandCell.value.toLowerCase().includes(value) ? "" : "none";
        });
    });

    // -------------------------
    // MODAL DE CREAR COMPUTADORA
    // -------------------------
    const btnCreate = document.getElementById("create");
    const createModal = document.getElementById("createModal");
    const btnCancelCreate = document.getElementById("btnCancelCreate");

    // Abrir modal
    btnCreate.addEventListener("click", () => {
        createModal.style.display = "flex";
    });

    // Cerrar modal
    btnCancelCreate.addEventListener("click", () => {
        createModal.style.display = "none";
    });

    console.log("Script inicializado correctamente");

});
