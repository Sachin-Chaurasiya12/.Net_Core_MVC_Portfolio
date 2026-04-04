
document.getElementById("Registerform").addEventListener("submit", function (e) {
    e.preventDefault();

    const email = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    const Name = document.getElementById("name").value;
    const repeat = document.getElementById("repeated").value;
    const DOB = document.getElementById("dob").value;
    const mobilenumber = document.getElementById("mobileNumber").value;

    if (!email || !password || !Name || !repeat) {
        alert("Fill the required fields");
        return;
    }
    if (repeat != password) {
        alert("Password mismatch")
        return;
    }

    fetch("/Account/Registerform", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            Name: Name,
            Email:email,
            Password: password,
            Dob: DOB,
            Phonenumber : mobilenumber

        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                alert("Registered Successfully")
            }
            else {
                alert(data.message);
            }
        })

});
