import React, {Component} from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Alert from '@material-ui/lab/Alert';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';

const useStyles = theme => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  }
});

class AddSensor extends Component {
  static displayName = AddSensor.name;
  
  constructor(props) {
    super(props);
    this.state = { name: "", sensorParameters: [{
        HumanReadableName: "",
        RequestName: ""
      },
        {
          HumanReadableName: "",
          RequestName: ""
        }] };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }
  
  async handleSubmit(event)
  {
    event.preventDefault();
    //await this.loginUser(this.state.email, this.state.password);
  }
  
  render () {
    const { classes } = this.props;
    var sensorParameters = this.state.sensorParameters;

    return (
        <Container component="main" maxWidth="sm">
          <CssBaseline/>
          <div className={classes.paper}>
            <Avatar className={classes.avatar}>
              <AddCircleIcon/>
            </Avatar>
            <Typography component="h1" variant="h5">
              Add Sensor
            </Typography>
            {this.state.error && <Alert xs variant="outlined" severity="error">{this.state.error}</Alert>}
            <form className={classes.form} noValidate onSubmit={this.handleSubmit}>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <TextField
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      id="name"
                      label="Sensor name"
                      name="name"
                      autoComplete="name"
                      autoFocus
                      value={this.state.name}
                      onChange={this.handleInputChange}
                  />
                </Grid>
                {sensorParameters.map((parameter, index) =>
                    <Grid key={index} container spacing={2} item>
                      <Grid item xs={12} sm={6}>
                        <TextField
                            name="humanReadableName"
                            variant="outlined"
                            required
                            fullWidth
                            id="humanReadableName"
                            label={"Readable parameter " + (index+1) + " name"}
                            value={parameter.HumanReadableName}
                            onChange={this.handleInputChange}
                        />
                      </Grid>
                      <Grid item xs={12} sm={6}>
                        <TextField
                            variant="outlined"
                            required
                            fullWidth
                            id="requestName"
                            label={"Parameter " + (index+1) + "  name for request"}
                            name="requestName"
                            value={parameter.RequestName}
                            onChange={this.handleInputChange}
                        />
                      </Grid>
                    </Grid>
                )}
                <Grid item sm={1}>
                  <AddCircleOutlineIcon fontSize="large" style={{color: "green"}}/>
                </Grid>
              </Grid>
              <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  className={classes.submit}
              >
                Add
              </Button>
            </form>
          </div>
        </Container>
    );
  }

  async loginUser(email, password) {
    try {
      //await AuthService.login(email, password);
    }
    catch(e)
    {
      this.setState({
        error: e
      });
    }
    
  }
}

AddSensor.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(useStyles)(AddSensor);