import * as React from 'react';
import './App.css';
import Button from '@mui/material/Button';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TextField from '@mui/material/TextField';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { styled } from '@mui/material/styles';


const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 14,
    },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));
class Compare extends React.Component {
    constructor(props) {
        super(props);
        this.fromDDD = "";
        this.toDDD = "";
        this.callTime = 0;
        this.selected = null;
        this.compareData = {};
        this.state = {
            items: [],
            compareData: [],
            planId: 0
        };

    }

    componentDidMount() {

        fetch(
            "https://localhost:7203/CallPlan/GetCallPlans")
            .then((res) => res.json())
            .then((json) => {
                this.setState({
                    items: json,
                    DataisLoaded: true
                });
            })

    }
    _handleChangeSelected(evento) {
        evento.stopPropagation();
        this.setState({ planId: evento.target.value });
    }
    _handleFromDDD(evento) {

        evento.stopPropagation();
        this.fromDDD = evento.target.value;
    };

    _handleToDDD(evento) {

        evento.stopPropagation();
        this.toDDD = evento.target.value;
    };

    _handleCalltime(evento) {

        evento.stopPropagation();
        this.callTime = evento.target.value;
    }

    async getData(evento) {

        evento.stopPropagation();

        evento.preventDefault();
        // POST request using fetch with async/await
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "fromDDD": this.fromDDD,
                "toDDD": this.toDDD,
                "callTime": parseInt(this.callTime),
                "callPlanId": this.state.planId
            })
        };

        console.log(requestOptions.body);


        const response = await fetch('https://localhost:7203/ComparePrice/PostCallCompare', requestOptions);
        const data = await response.json();
        this.setState({ compareData: data });
    }

    render() {

        return (
            <>
                <h2>Comparação de preços com e sem o plano VxTel</h2>
                <TableContainer component={Paper}>
                    <Table aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <StyledTableCell align="left">DDD Origem</StyledTableCell>
                                <StyledTableCell align="left">DDD Destino</StyledTableCell>
                                <StyledTableCell align="left">Tempo (min)</StyledTableCell>
                                <StyledTableCell align="left">Plano</StyledTableCell>
                                <StyledTableCell align="left">Preço com o Plano</StyledTableCell>
                                <StyledTableCell align="left">Preço sem o Plano</StyledTableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            <StyledTableRow key={this.state.compareData.id}>
                                <StyledTableCell align="left">{this.state.compareData.fromDDD}</StyledTableCell>
                                <StyledTableCell align="left">{this.state.compareData.toDDD}</StyledTableCell>
                                <StyledTableCell align="left">{this.state.compareData.callTime}</StyledTableCell>
                                <StyledTableCell align="left">{this.state.compareData.callPlanName}</StyledTableCell>
                                <StyledTableCell align="left">R$  {this.state.compareData.priceWithPlan != null ? parseFloat(this.state.compareData.priceWithPlan).toFixed(2) : ""}</StyledTableCell>
                                <StyledTableCell align="left">R$  {this.state.compareData.priceWithoutPlan != null ? parseFloat(this.state.compareData.priceWithoutPlan).toFixed(2) : ""}</StyledTableCell>
                            </StyledTableRow>

                        </TableBody>
                    </Table>
                </TableContainer>

                <FormControl variant="filled" fullWidth>
                    <div className="container">
                        <TextField
                            label="DDD Origem"
                            id="ddd-from"
                            required
                            onChange={this._handleFromDDD.bind(this)}
                            sx={{ m: 1, width: '15ch' }}
                            variant="filled"
                        />
                        <TextField
                            label="DDD Destino"
                            id="ddd-to"
                            required
                            onChange={this._handleToDDD.bind(this)}
                            sx={{ m: 1, width: '15ch' }}
                            variant="filled"
                        />
                        <TextField
                            label="Tempo Ligação"
                            id="call-time"
                            required
                            onChange={this._handleCalltime.bind(this)}
                            sx={{ m: 1, width: '20ch' }}
                            variant="filled"
                        />
                        
                        <TextField
                            label="Plano"
                            labelId="demo-simple-select-autowidth-label"
                            id="demo-simple-select-autowidth"
                            required
                            variant="filled"
                            select
                            sx={{ m: 1, width: '20ch' }}
                            // value={this.state.planId}
                            onChange={this._handleChangeSelected.bind(this)}
                        >
                            {this.state.items.map((item) => <MenuItem value={item.id}>{item.name}</MenuItem>)}    
                        </TextField>    
                        
                        <Button onClick={this.getData.bind(this)} sx={{ m: 1, width: '15ch' }} variant="outlined">Calcular</Button>
                    </div>
                </FormControl>
            </>
        )
    }
}

export default Compare;