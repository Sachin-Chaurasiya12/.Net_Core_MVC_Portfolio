document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const email = document.getElementById("Email").value;
    const password = document.getElementById("Password").value;

    // Basic validation
    if (!email || !password) {
        alert("Please fill all fields");
        return;
    }

    // Simulate login
    fetch("/Account/login", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            Email: email,
            Password: password
        }),
        credentials: 'same-origin'
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                window.location.href = "Dashboard/index";
            }
            else {
                alert(data.message);
            }
        })
});