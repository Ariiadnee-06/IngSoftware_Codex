document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM cargado, inicializando modal...");  // Log para verificar

    let formToSubmit = null;

    const modal = document.getElementById("confirmModal");
    const modalMessage = document.getElementById("modalMessage");
    const btnYes = document.getElementById("btnYes");
    const btnNo = document.getElementById("btnNo");

    // Verificar si los elementos existen
    if (!modal) console.error("Error: No se encontró el modal con ID 'confirmModal'");
    if (!modalMessage) console.error("Error: No se encontró el mensaje del modal");
    if (!btnYes) console.error("Error: No se encontró el botón 'btnYes'");
    if (!btnNo) console.error("Error: No se encontró el botón 'btnNo'");

    // Cuando se hace clic en Guardar
    document.querySelectorAll(".confirm-save").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            formToSubmit = this.closest("form");
            modalMessage.textContent = "¿Deseas guardar los cambios?";
            modal.style.display = "flex";
            console.log("Modal de guardar mostrado");  // Para depuración
        });
    });

    // Cuando se hace clic en Eliminar
    document.querySelectorAll(".confirm-delete").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            formToSubmit = this.closest("form");
            modalMessage.textContent = "¿Seguro que deseas eliminar este usuario?";
            modal.style.display = "flex";
            console.log("Modal de eliminar mostrado");  // Para depuración
        });
    });

    // Botón SI (Aceptar)
    btnYes.addEventListener("click", function () {
        if (formToSubmit) {
            formToSubmit.submit();
        }
        modal.style.display = "none";
        formToSubmit = null;
        console.log("Formulario enviado y modal cerrado");
    });

    // Botón NO (Cancelar)
    btnNo.addEventListener("click", function () {
        modal.style.display = "none";
        formToSubmit = null;
        console.log("Modal cancelado");
    });

    console.log("Modal inicializado correctamente");
});

//Buscador
document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");
    const rows = document.querySelectorAll("tbody tr");

    searchInput.addEventListener("input", function () {
        const value = this.value.toLowerCase().trim();

        rows.forEach(row => {
            // Selecciona SOLO la celda del username
            const usernameCell = row.querySelector('input[name="Brand"]');

            if (usernameCell) {
                const username = usernameCell.value.toLowerCase();

                // Mostrar u ocultar fila
                row.style.display = username.includes(value) ? "" : "none";
            }
        });
    });
});
