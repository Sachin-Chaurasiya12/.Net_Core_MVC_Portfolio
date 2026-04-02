document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    // Basic validation
    if (!email || !password) {
        alert("Please fill all fields");
        return;
    }

    // Simulate login
    fetch("/Dashboard/login", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            username: email,
            password: password
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                alert("login successfully");
            }
            else {
                alert("wrong credientials");
            }
        })
});