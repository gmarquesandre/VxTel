import * as React from 'react';
import Button from '@mui/material/Button';


class Compare extends React.Component {


    async getData() {
        console.log("Entrou");
        // POST request using fetch with async/await
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "fromDDD": "011",
                "toDDD": "016",
                "callTime": 40,
                "callPlanId": 1
              })
        };
        const response = await fetch('https://localhost:7203/ComparePrice/PostCallCompare', requestOptions);
        const data = await response.json();
        this.setState({ info: data });
    }

    render() {    
        return (
            <>
                <h2>Comparação de preços com plano e sem</h2>
                <Button onClick={() => this.getData()} variant="outlined">Calcular</Button>
            </>
        )
    }
}

export default Compare;