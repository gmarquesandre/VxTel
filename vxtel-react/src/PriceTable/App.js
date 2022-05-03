import * as React from 'react';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import CircularProgress from '@mui/material/CircularProgress';
import Box from '@mui/material/Box';

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
class PriceTable extends React.Component {

    // Constructor 
    constructor(props) {
        super(props);

        this.state = {
            items: [],
            DataisLoaded: false
        };
    }

    // ComponentDidMount is used to
    // execute the code 
    componentDidMount() {
        fetch(
            "https://localhost:7203/CallPrice/GetCallPrices")
            .then((res) => res.json())
            .then((json) => {
                this.setState({
                    items: json,
                    DataisLoaded: true
                });
            })
    }
    render() {
        const { DataisLoaded, items } = this.state;
        if (!DataisLoaded) return 
            <Box sx={{ display: 'flex' }}>
            <CircularProgress />
            </Box>;

        return (
            <>
        
            <h1>Tabela de Preços</h1>
            
            <TableContainer component={Paper}>
            <Table aria-label="customized table">
              <TableHead>
                <TableRow>
                  <StyledTableCell align="left">DDD Origem</StyledTableCell>
                  <StyledTableCell align="left">DDD Destino</StyledTableCell>
                  <StyledTableCell align="left">Preço por Minuto</StyledTableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {items.map((row) => (
                  <StyledTableRow key={row.id}>
                    <StyledTableCell align="left">{row.fromDDD}</StyledTableCell>
                    <StyledTableCell align="left">{row.toDDD}</StyledTableCell>
                    <StyledTableCell align="left">R$  {row.pricePerMinute}</StyledTableCell>
                </StyledTableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
          </>
        );
    }
}

export default PriceTable;