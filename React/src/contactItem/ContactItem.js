

function ContactItem(props) {

    var ImageChat = "https://cdn-icons.flaticon.com/png/512/924/premium/924915.png?token=exp=1652728089~hmac=e7e756d9f3e40f26bd2bd3413f7a987c"
    

    // function calculates the time that passed since time argument and return a string represnts it 
    const timePassedSince = (time) => {
        let currTime = new Date();
        let diffTime = Math.abs(currTime - time);
        diffTime = diffTime / 1000;
        if(props.lastMessage === "") {
            return "";
        } else if(diffTime < 60) {
            return "Right now";
        } else if((diffTime / 60) < 60) {
            return Math.round(diffTime / 60) + " minutes ago"
        } else if((diffTime / 60*60) < 24) {
            return Math.round(diffTime / 60*60) + " hours ago"
        }
        return time.getDate() + "/" + (time.getMonth() + 1) + "/" + time.getFullYear();
    }

    return (
        <ul className="list-group users-list">
            <button type="button" className="list-group-item list-group-item-action" onClick={() => {props.setDetails(props.contactDetails)}}>
                <div className="sideBar-body">
                    <div className="avatar-icon">
                        <img src={ImageChat}></img>
                    </div>
                    <div className="sideBar-name">{props.contactName}
                    </div>
                    <div className="lastMessage">{props.lastMessage}</div>
                    <span className="time-meta">{timePassedSince(props.sentTime)}</span>
                </div>
            </button>
        </ul>
    );
}

export default ContactItem