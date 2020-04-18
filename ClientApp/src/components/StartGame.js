import { Input, Label, Form, Button } from 'reactstrap';
import React, { useState, useEffect } from 'react';
import * as signalR from '@aspnet/signalr';
import { useHistory, useLocation } from 'react-router-dom';

const StartGame = (props) => {
    const startingGame = props.start;
    const [username, setUsername] = useState('');
    const [roomCode, setRoomCode] = useState('');
    const [connection, setConnection] = useState(null);
    const history = useHistory();
    const location = useLocation();

    useEffect(() => {
        const params = new URLSearchParams(location.search);
        const code = params.get('roomCode');
        if (code) {
            setRoomCode(code);
        }
    }, [location]);

    const submitForm = (e) => {
        e.preventDefault();
        console.log('Submitting with name: ', username);
        const buildingConnection = new signalR.HubConnectionBuilder()
            .withUrl(`/gameHub?username=${username}&roomcode=${roomCode}`)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        buildingConnection.start();
        buildingConnection.on('ReceiveRoomCode', (code) => {
            console.log('ROOM CODE: ', code);
            setRoomCode(code);
            history.push(`/game/${code}`, {user: {name: username}, roomCode: code});
        });

        connection.start();
        setConnection(buildingConnection);
    }

    return (
        <div>
            <Form onSubmit={(e) => submitForm(e)}>
                <Label for="username">Name</Label>
                <Input type="text" name="username" onChange={(e) => setUsername(e.target.value)} />
                {(startingGame 
                    ? null 
                    : (<div>
                        <Label for="username">Room Code</Label>
                        <Input type="text" name="roomCode" value={roomCode} onChange={(e) => setRoomCode(e.target.value)} />
                        </div>) )}
                <Button onClick={submitForm}>Submit</Button>
            </Form>
        </div>
    )
}

export default StartGame;