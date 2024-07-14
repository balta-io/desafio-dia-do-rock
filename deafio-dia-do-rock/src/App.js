import './App.css';
import Navbar from './components/Navbar';

function App() {
  return (
    <div className='flex'>
      <Navbar />
      <div className='w-full bg-black'>
        <p className='text-white text-center'>Hello World</p>
      </div>
    </div>
  );
}

export default App;
