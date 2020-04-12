import { Input, Label, Form, Button } from 'reactstrap';
import React, { useState, useEffect } from 'react';
import * as signalR from '@aspnet/signalr';

const StartGame = (props) => {
    let connection = null;
    const startingGame = props.start;
    const [username, setUsername] = useState('');
    const [roomCode, setRoomCode] = useState('');

    useEffect(() => {
        // connection = new signalR.HubConnectionBuilder()
        //     .withUrl("/gameHub")
        //     .configureLogging(signalR.LogLevel.Information)
        //     .build();

        // connection.start();

    }, []);

    const submitForm = (e) => {
        e.preventDefault();
        console.log('Submitting with name: ', username);
        connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")
            .configureLogging(signalR.LogLevel.Information)
            .build();

        connection.start();
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
                        <Input type="text" name="roomCode" onChange={(e) => setRoomCode(e.target.value)} />
                        </div>) )}
                <Button onClick={submitForm}>Submit</Button>
            </Form>
        </div>
    )
}

export default StartGame;