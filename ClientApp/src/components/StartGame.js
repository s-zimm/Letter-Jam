import { Input, Label, Form, Button } from 'reactstrap';
import React, { useState } from 'react';

const StartGame = (props) => {
    const [username, setUsername] = useState('');

    const submitForm = () => {
        console.log('Submitting with name: ', username);
    }
    
    return (
        <div>
            <Form onSubmit={submitForm}>
                <Label for="username">Name</Label>
                <Input type="text" name="username" onChange={(e) => setUsername(e.target.value)} />
                {(props.start 
                    ? null 
                    : (<div>
                        <Label for="username">Room Code</Label>
                        <Input type="text" name="roomCode" />
                        </div>) )}
                <Button type="submit">Submit</Button>
            </Form>
        </div>
    )
}

export default StartGame;