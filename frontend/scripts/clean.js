const del = require('del');
 
del(['app/**/*.js', 'app/**/*.js.map']).then(paths => {
    console.log('Deleted files and folders:\n', paths.join('\n'));
});