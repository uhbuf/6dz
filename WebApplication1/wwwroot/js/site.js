function simplePost(val1, val2) {
    let postData = {
        Value1:val1,
        Value2:val2
    };
    $.ajax({
        url: 'Home/SimplePost/1',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(postData),
        success: function (result) {
            console.log(result);
        }
    });
}
