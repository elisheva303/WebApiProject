const postdata = async () => {
    const emailInput = document.getElementById("regUserName");
    const passwordInput = document.getElementById("regPassword");
    const firstNameInput = document.getElementById("regFirstName");
    const lastNameInput = document.getElementById("regLastName");

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

