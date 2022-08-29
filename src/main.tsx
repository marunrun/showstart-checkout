import React, {useEffect} from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './index.css'
import './App.css'
import {BrowserRouter} from "react-router-dom";
import {post} from "./util/http";
import {MAKE_TOKEN} from "./network/request";


ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
      <BrowserRouter>
          <App />
      </BrowserRouter>
  </React.StrictMode>
)
