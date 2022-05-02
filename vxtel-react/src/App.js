import './App.css';
import PlanTable from './PlanTable/App';
import PriceTable from './PriceTable/App';
import Header from './Header/App'
import Compare from './Compare/App';

function App() {
  return (
    <> 
    <div className="AppStyle">   
      <Header />
      <PriceTable />
      <PlanTable />      
      <Compare />
    </div> 
    </>
  );
}

export default App;
