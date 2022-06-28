import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import {Add, Image} from "@material-ui/icons";
import {NavMenu} from "./NavMenu";
import NotFound from "./NotFound";
import Unauthorized from "./Unauthorized";
import {NavLink} from "react-router-dom";
import AddBoxIcon from "@material-ui/icons/AddBox";
import {green} from "@material-ui/core/colors";
import Grid from "@material-ui/core/Grid";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <Grid alignItems="stretch" container spacing={2}>
          <Grid style={{display: "flex", flexDirection: "column"}} item xs={6} sm={6} lg={6}>
              <label style={{fontSize: '40px'}}>Welcome to MySensors! Let`s test our new control panel!</label>
          </Grid>
          <Grid style={{display: "flex", flexDirection: "column"}} item xs={6} sm={6} lg={6}>
            <img src={process.env.PUBLIC_URL + '/screen1.png'} />
          </Grid>
          
        </Grid>
    );
  }
}
