// ======== Referencias a los elementos =========
const btnLoginSideBar = document.getElementById('login-sidebar');
const btnRegisterSideBar = document.getElementById('register-sidebar');
const divForms = document.getElementById('forms');
const divSideBar = document.getElementById('sidebar');
const loginMessage = document.getElementById('login-message');
const registerMessage = document.getElementById('register-message');

// ======== Cambiar entre vistas de Login y Registro =========
btnLoginSideBar?.addEventListener('click', changeLogin);
btnRegisterSideBar?.addEventListener('click', changeRegister);

function changeLogin() {
    divForms.classList.remove('active');
    divSideBar.classList.remove('active');
    if (loginMessage) loginMessage.textContent = '';
    if (registerMessage) registerMessage.textContent = '';
}

function changeRegister() {
    divForms.classList.add('active');
    divSideBar.classList.add('active');
    if (loginMessage) loginMessage.textContent = '';
    if (registerMessage) registerMessage.textContent = '';
}

// ======== Menú móvil (para responsive) =========
const navMenu = document.getElementById('nav_menu');
const navToggle = document.getElementById('nav_toggle');
const navClose = document.getElementById('nav_close');

if (navToggle) {
    navToggle.addEventListener('click', () => {
        navMenu.classList.add('show_menu');
    });
}

if (navClose) {
    navClose.addEventListener('click', () => {
        navMenu.classList.remove('show_menu');
    });
}

document.addEventListener('DOMContentLoaded', function () {
    const toast = document.getElementById('spam-toast');
    if (!toast) return;

    const closeBtn = document.getElementById('spam-close');

    // Mostrar: ya está visible por render del servidor. Programamos cierre automático.
    const AUTO_HIDE_MS = 3500; // 3.5 segundos

    // Cierra con animación suave
    function hideToast() {
        // animación de salida
        toast.style.transition = 'opacity 0.35s ease, transform 0.35s ease';
        toast.style.opacity = '0';
        toast.style.transform = 'translateY(-10px) scale(0.98)';
        // remover del DOM después de la animación
        setTimeout(() => {
            if (toast && toast.parentNode) toast.parentNode.removeChild(toast);
        }, 380);
    }

    // Cierre manual
    if (closeBtn) {
        closeBtn.addEventListener('click', function (e) {
            e.preventDefault();
            hideToast();
        });
    }

    // Auto-cierre
    setTimeout(hideToast, AUTO_HIDE_MS);
});
