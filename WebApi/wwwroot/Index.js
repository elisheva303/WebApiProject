const postdata = async () => {
    const emailInput = document.getElementById("regUserName");
    const passwordInput = document.getElementById("regPassword");
    const firstNameInput = document.getElementById("regFirstName");
    const lastNameInput = document.getElementById("regLastName");

    //In JavaScript, variables are written in camelCase: postUser
    const PostUser = {
        Email: emailInput.value,
        Password: passwordInput.value,
        FirstName: firstNameInput.value, 
        LastName: lastNameInput.value 
    };

    try {
        const response = await fetch('api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(PostUser)
        });

        if (response.ok) {
            alert("succses");
            const postres = await response.json();
            console.log(postres);
        } else {
            alert("error ");
        }
    } catch (error) {
        console.error("error", error);
    }
};
const login = async () => {
    const emaillogin = document.getElementById("UserName");
    const passwordlogin = document.getElementById("Password");
    

    const loginUser = {
        Email: emaillogin.value,
        Password: passwordlogin.value,
        
    };

    try {
        const response = await fetch('api/Users/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        });

        if (response.ok)
        {
            const postres = await response.json();
            sessionStorage.setItem("user", JSON.stringify(postres) )
            alert("succses");

        }
        else
        {
            alert("Incorrect email or password ");
        }
    } catch (error) {
        console.log("error", error);
    }
};
const strongPassword = async () => {
    const passwordInput = document.getElementById("regPassword").value;

    try {
        const response = await fetch('api/Password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(passwordInput)
        });

        if (response.ok)
        {
            alert("check your password...")
            const score = await response.json();
            document.getElementById("graf").value = score;

            const colors = ["#d32f2f", "#f57c00", "#fbc02d", "#7cb342", "#2e7d32"];
            document.getElementById("graf").style.color = colors[score];
        }
        else
        {
            alert("password is not strong ");
        }
    } catch (error) {
        console.log("error", error);
    }
};

