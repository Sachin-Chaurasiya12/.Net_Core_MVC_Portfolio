// 1. Fixed the event listener name
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const email = document.getElementById("Email").value;
    const password = document.getElementById("Password").value;

    if (!email || !password) {
        alert("Please fill all fields");
        return;
    }

    fetch("/Account/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify({
            Email: email,
            Password: password
        }),
        credentials: 'same-origin'
    })
        .then(res => {
            if (!res.ok) throw new Error("Server returned " + res.status);
            return res.json();
        })
        .then(data => {
            if (data.success) {
                window.location.href = "/Dashboard/index";
            } else {
                alert(data.message);
            }
        })
        .catch(err => console.error("Fetch error:", err));
});