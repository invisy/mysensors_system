import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import AddSensor from "./AddSensor";
import {Add} from "@material-ui/icons";
import {NavMenu} from "./NavMenu";
import Grid from "@material-ui/core/Grid";
import {Link} from "react-router-dom";
import {FormControl, MenuItem, Paper, Select} from "@material-ui/core";
import TextField from "@material-ui/core/TextField";
import {ArgumentAxis, Chart, SplineSeries, BarSeries, ValueAxis} from "@devexpress/dx-react-chart-material-ui";
import {Animation, EventTracker, SelectionState} from "@devexpress/dx-react-chart";


export class ShowSensorDetails extends Component {
  static displayName = ShowSensorDetails.name;
  
  constructor(props) {
    super(props);
    this.DaysEnum = Object.freeze({"Series":1, "BarSeries":2, "FreqHist":3})
    this.state = { chartType: this.DaysEnum.Series, 
        dataRange: 60, 
        values:[{ splineValue: 20.1, argument: '17:25:17'},{ splineValue: 23.5, argument: '17:26:17'},{ splineValue: 15.2, argument: '19:25:16'}],
        selection: null
    };
    
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
      const target = event.target;
      const value = target.type === 'checkbox' ? target.checked : target.value;
      const name = target.name;
      this.setState({
          [name]: value
      });
  }
  
  render () {
    return (
        <Grid maxWidth="xs" container spacing={2}>
          <Grid item xs={4}>
            <Select name="chartType" onChange={this.handleInputChange} style={{minWidth: 120}} value={this.state.chartType}>
              <MenuItem value={this.DaysEnum.Series}>Series</MenuItem>
              <MenuItem value={this.DaysEnum.BarSeries}>Histogram</MenuItem>
              <MenuItem value={this.DaysEnum.FreqHist}>Freqency histogram</MenuItem>
            </Select>
          </Grid>
          <Grid item xs={4}>
              <Select name="dataRange" onChange={this.handleInputChange} style={{minWidth: 120}} value={this.state.dataRange}>
                  <MenuItem value="60">Hour</MenuItem>
                  <MenuItem value="1440">Day</MenuItem>
                  <MenuItem value="44640">Month</MenuItem>
                  <MenuItem value="16293600">Year</MenuItem>
              </Select>
          </Grid>
          <Grid item xs={12}>
            <Paper>
                {this.state.selection != null && <span>Selected value: {this.state.selection}</span>}
                <Chart data={this.state.values}>
                    <ArgumentAxis />
                    <ValueAxis />
                    {this.state.chartType === this.DaysEnum.Series && <SplineSeries name="spline" valueField="splineValue" argumentField="argument" /> }
                    {this.state.chartType === this.DaysEnum.BarSeries && <BarSeries name="spline" valueField="splineValue" argumentField="argument" /> }
                    <Animation />
                </Chart>
            </Paper>
          </Grid>  
        </Grid>
    );
  }
}
