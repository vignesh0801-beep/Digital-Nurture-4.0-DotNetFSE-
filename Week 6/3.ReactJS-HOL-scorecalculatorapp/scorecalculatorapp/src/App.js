// import logo from './logo.svg';
// import './App.css';

import { CalculateScore } from '../src/Components/CalculateScore';

function App() {
  return (
    <div>
      <CalculateScore
        Name="Sourav Kumar Parida"
        School="Kiit University"
        total={284}
        goal={300}
      />
    </div>
  );
}

export default App;
