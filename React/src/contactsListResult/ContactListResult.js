import UsersData from "../usersData/UsersData";
import ContactItem from "../contactItem/ContactItem";

function ContactListResult(props) {

    const contactsList = props.contactsList.map((contact, key) => {
        return <ContactItem contactDetails={contact} contactName={contact.name} lastMessage={contact.last} 
                            sentTime={new Date(Date.parse(contact.lastDate))} 
                            showChat={props.showChat} setDetails={props.setDetails}/>
    });

    return (
        <div className="sideBar">
            {contactsList}
        </div>
    );
}

export default ContactListResult