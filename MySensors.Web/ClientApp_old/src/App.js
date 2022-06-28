import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import Sensors from "./components/Sensors";
import AddSensor from "./components/AddSensor";
import {ShowSensorDetails} from "./components/ShowSensorDetails";

import './custom.css'
import SensorsProperties from "./components/SensorsProperties";
import NotFound from "./components/NotFound";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/sign-in' component={SignIn} />
            <Route exact path='/sign-up' component={SignUp} />
            <Route exact path='/sensors/' component={Sensors} />
            <Route exact path='/sensors/add' component={AddSensor} />
            <Route exact path='/sensors/details/:id' component={ShowSensorDetails} />
            <Route exact path='/sensors/properties/:id/' component={SensorsProperties} />
            <Route component={NotFound} />
        </Switch>
      </Layout>
    );
  }
}
