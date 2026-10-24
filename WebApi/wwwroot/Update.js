
const user1 = JSON.parse(sessionStorage.getItem("user"));

const emailInput = document.getElementById("emailupdate").value;
const passwordInput = document.getElementById("updatePassword").value;
const firstNameInput = document.getElementById("updateFirstName").value;
const lastNameInput = document.getElementById("updateLastName").value;

// Email.value = user1.emailInput;
// Password.value = user1.passwordInput;
// FirstName.value = user1.firstNameInput;
// LastName.value = user1.lastNameInpu;


async function update() 
{
    const emailInput = document.getElementById("emailupdate");
    const passwordInput = document.getElementById("updatePassword");
    const firstNameInput = document.getElementById("updateFirstName");
    const lastNameInput = document.getElementById("updateLastName");


    const updateUser = {
        Email: emailInput.value,
        Password: passwordInput.value,
        FirstName: firstNameInput.value,
        LastName: lastNameInput.value
    };

         const id = user1.id;
    
    try {
        console.log("User:", user1);
        console.log("ID:", id);
        const response = await fetch(`/api/Users/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUser)
        });

        if (response.ok) {
            alert("update success");
            const postres = await response.json();
            console.log(postres);
        } else {
            alert("error");
        }
    } catch (error) {
        console.error("error", error);
    }
}
