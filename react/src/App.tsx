import { ToastContainer } from 'react-toastify'
import './App.css'
import { BrowserRouter } from 'react-router'
import ls from './utility/localStorage'
import key from './common/constant/key'
import util from './common/utils/utils'
import PublicLayout from './layout/public'
import PrivateLayout from './layout/private'

function App() {
  return (
    <>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
      <BrowserRouter>
        {util.isNullOrEmpty(ls.load(key.lsUser)) ? <PublicLayout /> : <PrivateLayout />}
      </BrowserRouter>
    </>
  )
}

export default App
