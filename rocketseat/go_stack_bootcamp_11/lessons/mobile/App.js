import React from 'react';
import {StatusBar, StyleSheet, Text, View} from 'react-native';

const App = () => {
  return (
    <>
      <StatusBar backgroundColor="#7159c1" barStyle="light-content" />

      <View style={styles.container}>
        <Text style={styles.text}>Hello World</Text>
      </View>
    </>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    backgroundColor: '#7159c1',
    justifyContent: 'center',
    flex: 1,
  },
  text: {
    color: '#fff',
    fontSize: 20,
  },
});

export default App;
