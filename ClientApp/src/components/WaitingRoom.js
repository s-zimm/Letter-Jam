import React, { useState, useEffect } from 'react';
import { useLocation, useParams, useHistory } from 'react-router-dom';

const WaitingRoom = () => {
    const location = useLocation();
    const params = useParams();
    const history = useHistory();
    const [users, setUsers] = useState([]);
    const [roomCode, setRoomCode] = useState('');

    useEffect(() => {
        if (!location.state) {
            return history.push(`/join-game?roomCode=${params.roomCode}`);
        } else {
            const newUser = location.state.user;
            const roomCode = location.state.roomCode;
            console.log('State for adding user: ', location.state);
            setRoomCode(roomCode);
            setUsers([ ...users, newUser ]);
        }
    }, [location]);

    const renderUsersList = () => users.map(user => (<li>{user.name}</li>));

    return (
        <div>
            <h1>{roomCode}</h1>
            <ol>
                {renderUsersList()}
            </ol>
        </div>
    )
}

export default WaitingRoom;