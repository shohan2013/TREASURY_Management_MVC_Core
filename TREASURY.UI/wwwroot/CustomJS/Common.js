//$(document).ready(function () {
//    //DeleteMul();
//});


function isNumber(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57) && evt.target.value.indexOf('-') === 0)
        return false;

    return true;
}


function ViewImageFromAPI(PROCESSCODE) {

    let ALPHA = PROCESSCODE.substring(0, 2);
    userFolder = ALPHA + "/" + PROCESSCODE.toUpperCase();

     //alert(ALPHA)
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {
           //  alert('result')
            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };


            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                   //  alert('login')
                    const authorizationToken = 'Bearer ' + response.token;

                    var apiUrl = data.downloadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password +
                        "&userFolder=" + userFolder;

                    //alert(apiUrl);

                    $.ajax({
                        url: apiUrl,
                        type: 'GET',
                        headers: {
                            'Authorization': authorizationToken,
                            'Content-Type': 'application/json',
                        },
                        contentType: false,
                        processData: false,
                        success: function (result) {
                             // alert(result.base64FileResponse[0].fileName)
                            var html = "";
                            var extension = "";
                            var slno = 1;

                            for (var i = 0; i < result.base64FileResponse.length; i++) {
                                extension = result.base64FileResponse[i].fileName.split('.').pop();

                                var slno = i + 1;

                                html += '<tr>';
                                html += '<td>' + parseInt(slno) + '</td>';
                                html += '<td>' + result.base64FileResponse[i].fileName + '</td>';
                                //html += "<td><a  href='data:'" + extension + "';base64," + result.base64FileResponse[i].base64Content + "' download> Download</a></td>";
                                html += "<td><button type='button' class='btn btn-primary btn-sm insert' onclick='Download(\"" + result.base64FileResponse[i].fileName + "\",\"" + result.base64FileResponse[i].base64Content + "\",\"" + extension + "\")'><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                //html += '<td><button type="button" class="btn btn-primary btn-sm insert" onclick="Download()"><span class="fas fa-arrow-circle-down"></span> Download</button></td>';
                                html += '</tr>';
                            }
                            $("#tblData").empty().append(html);
                            // $("#tblData").append(html);
                        }
                    });
                }
            });
        }
    });
}

function ViewImageFromAPIOne(PROCESSCODE) {

    let ALPHA = PROCESSCODE.substring(0, 2);
    userFolder = ALPHA + "/" + PROCESSCODE.toUpperCase();

    //alert(ALPHA)
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {
            //  alert('result')
            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };


            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                    //  alert('login')
                    const authorizationToken = 'Bearer ' + response.token;

                    var apiUrl = data.downloadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password +
                        "&userFolder=" + userFolder;

                    console.log(apiUrl);
               

                    $.ajax({
                        url: apiUrl,
                        type: 'GET',
                        headers: {
                            'Authorization': authorizationToken,
                            'Content-Type': 'application/json',
                        },
                        contentType: false,
                        processData: false,
                        success: function (result) {
                            console.log(result);
                            // alert(result.base64FileResponse[0].fileName)
                            var html = "";
                            var extension = "";
                            var slno = 1;

                            for (var i = 0; i < result.base64FileResponse.length; i++) {
                                extension = result.base64FileResponse[i].fileName.split('.').pop();

                                var slno = i + 1;

                                html += '<tr>';
                                html += '<td>' + parseInt(slno) + '</td>';
                                html += '<td>' + result.base64FileResponse[i].fileName + '</td>';
                                //html += "<td><a  href='data:'" + extension + "';base64," + result.base64FileResponse[i].base64Content + "' download> Download</a></td>";
                                html += "<td><button type='button' class='btn btn-primary btn-sm insert' onclick='Download(\"" + result.base64FileResponse[i].fileName + "\",\"" + result.base64FileResponse[i].base64Content + "\",\"" + extension + "\")'><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                //html += '<td><button type="button" class="btn btn-primary btn-sm insert" onclick="Download()"><span class="fas fa-arrow-circle-down"></span> Download</button></td>';
                                html += '</tr>';
                            }
                            console.log(html);
                            $("#tblDataDoc").empty().append(html);
                            // $("#tblData").append(html);
                        }
                    });
                }
            });
        }
    });
}


function Download(name, file, extension) {

    if (extension == "txt") {
        extension = "plain/text";
    }
    else if (extension == "png") {
        extension = "data:application/octet-stream";
    }
    else if (extension == "jpg") {
        extension = "data:application/octet-stream;";
    }
    else if (extension == "jpeg") {
        extension = "data:application/octet-stream;";
    }
    else if (extension == "pdf") {
        extension = "application/pdf";
    }
    else if (extension == "xlsx") {
        extension = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    }

    var link = document.createElement("a");
    document.body.appendChild(link);
    link.setAttribute("type", "hidden");
    link.href = "data:'" + extension +"';base64," + file;
    link.download = name;
    link.click();
    document.body.removeChild(link);

}


function UploadFileUsingAPI(PROCESSCODE) {
    PROCESSCODE = PROCESSCODE.split(':')[1];
    var parts = PROCESSCODE.split("-"); 
 
    var NUMBER = parts[parts.length - 1]; 
    
    
    let ALPHA = PROCESSCODE.substring(0, 2);

    let concat = "/";
    userFolder = ALPHA.trim() + concat.trim() + PROCESSCODE.trim().toUpperCase();
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {

            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                   // alert(response.token)
                    const authorizationToken = 'Bearer ' + response.token;
                    var apiUrl = data.uploadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password + "&userFolder=" + userFolder.trim();
                    
                    const fileInput = document.getElementById("fileInput");
                   
                    const selectedFiles = fileInput.files;
                   // alert(selectedFiles.length)
                    if (selectedFiles.length === 0) {

                        return;
                    }
                    else {

                        var formdata = new FormData();
                        for (let i = 0; i < selectedFiles.length; i++) {

                            formdata.append("formFiles", selectedFiles[i]);
                        }

                        $('#fileInput').val('');
                        formdata.append("ProcessID", NUMBER);
                        formdata.append("Processcode", PROCESSCODE);
                        formdata.append("ProcessName", ALPHA);

                        console.log(formdata);
                    
                        $.ajax({
                            url: apiUrl,
                            type: 'POST',
                            headers: {
                                'Authorization': authorizationToken
                            },

                            data: formdata,
                            contentType: false,
                            processData: false,
                            success: function (result) {
                                   
                                $.ajax({
                                    url: "/Common/FileUpload",
                                    type: 'POST',
                                    data: formdata,
                                    processData: false,
                                    contentType: false,
                                    success: function (response) {
                                        
                                       //alert('done')
                                    }
                                });
                            }
                        });
                    }
                }
            });
        }
    });
}


function UploadFileUsingAPIOne(PROCESSCODE) {
    
    PROCESSCODE = PROCESSCODE.split(':')[1];
    var parts = PROCESSCODE.split("-");

    var NUMBER = parts[parts.length - 1];


    let ALPHA = PROCESSCODE.substring(0, 2);

    let concat = "/";
    userFolder = ALPHA.trim() + concat.trim() + PROCESSCODE.trim().toUpperCase();
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {

            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                    // alert(response.token)
                    const authorizationToken = 'Bearer ' + response.token;
                    var apiUrl = data.uploadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password + "&userFolder=" + userFolder.trim();

                    const fileInput = document.getElementById("fileInputDetails");

                    const selectedFiles = fileInput.files;
                    // alert(selectedFiles.length)
                    if (selectedFiles.length === 0) {

                        return;
                    }
                    else {

                        var formdata = new FormData();
                        for (let i = 0; i < selectedFiles.length; i++) {

                            formdata.append("formFiles", selectedFiles[i]);
                        }

                        $('#fileInput').val('');
                        formdata.append("ProcessID", NUMBER);
                        formdata.append("Processcode", PROCESSCODE);
                        formdata.append("ProcessName", ALPHA);

                        console.log(formdata);

                        $.ajax({
                            url: apiUrl,
                            type: 'POST',
                            headers: {
                                'Authorization': authorizationToken
                            },

                            data: formdata,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                                $.ajax({
                                    url: "/Common/FileUpload",
                                    type: 'POST',
                                    data: formdata,
                                    processData: false,
                                    contentType: false,
                                    success: function (response) {

                                        //alert('done')
                                    }
                                });
                            }
                        });
                    }
                }
            });
        }
    });
}


function EUploadFileUsingAPI(PROCESSCODE) {
    // alert(PROCESSCODE)
    PROCESSCODE = PROCESSCODE.split(':')[1];
    var parts = PROCESSCODE.split("-");

    var NUMBER = parts[parts.length - 1];


    //var lastFourDigits = lastPart.slice(-4);
    //let NUMBER = lastPart.slice(-4); 
    //let NUMBER =  PROCESSCODE.substring(PROCESSCODE.length - 4);
    let ALPHA = PROCESSCODE.substring(0, 2);

    let concat = "/";
    userFolder = ALPHA.trim() + concat.trim() + PROCESSCODE.trim().toUpperCase();
    //alert(PROCESSCODE.trim().toUpperCase())
    //alert(NUMBER)
    //alert(ALPHA)
    //alert(userFolder)
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {

            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };
            //alert(data.loginUrl)
            //alert(requestData)

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                    //   alert(response.token)
                    const authorizationToken = 'Bearer ' + response.token;
                    var apiUrl = data.uploadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password + "&userFolder=" + userFolder.trim();


                    const fileInput = document.getElementById("efileInput");

                    const selectedFiles = fileInput.files;

                    if (selectedFiles.length === 0) {

                        return;
                    }
                    else {

                        var formdata = new FormData();
                        for (let i = 0; i < selectedFiles.length; i++) {

                            formdata.append("formFiles", selectedFiles[i]);
                        }
                        $('#fileInput').val('');
                        formdata.append("ProcessID", NUMBER);
                        formdata.append("Processcode", PROCESSCODE);
                        formdata.append("ProcessName", ALPHA);


                        $.ajax({
                            url: apiUrl,
                            type: 'POST',
                            headers: {
                                'Authorization': authorizationToken
                            },

                            data: formdata,
                            contentType: false,
                            processData: false,
                            success: function (result) {

                                $.ajax({
                                    url: "/Common/FileUpload",
                                    type: 'POST',
                                    data: formdata,
                                    processData: false,
                                    contentType: false,
                                    success: function (response) {


                                    }
                                });
                            }
                        });
                    }
                }
            });
        }
    });
}

function UploadFileDocumentBrowseUsingAPI(CHILDNAME, ROOTDOCCODE, DOCHEADER, DOCLINE) {
    
    if ($("#txttypeid").val() == '') {
        if ($("#etxttypeid").val() == 1) {
            var pickpack = "SH";
            var pickpackID = $("#etxtShPo").val();
            // var pickpacknum = pickpack.split('[');
            var pickpacknumber = pickpack + pickpackID.toString();

        }
        if ($("#etxttypeid").val() == 2) {
            var pickpack = "PO";
            var pickpackID = $("#etxtShPo").val();
            // var pickpacknum = pickpack.split('[');
            var pickpacknumber = pickpack + pickpackID.toString();

        }
    }
    if ($("#txttypeid").val() == 1) {
        var pickpack = "SH";
        var pickpackID = $("#txtShPo").val();
       // var pickpacknum = pickpack.split('[');
        var pickpacknumber = pickpack + pickpackID.toString();
    
    }
    if ($("#txttypeid").val() == 2) {
        var pickpack = "PO";
        var pickpackID = $("#txtShPo").val();
        // var pickpacknum = pickpack.split('[');
        var pickpacknumber = pickpack + pickpackID.toString();

    }
    //else {
  
    //    var pickpack = $("#etxtPickPack").val();
    //    var pickpackID = $("#etxtPickPackID").val();
    //    var pickpacknum = pickpack.split('[');
    //    var pickpacknumber = pickpacknum[0];
    //}
  
   
    let concat = "/";
    
    /* userFolder = ROOTDOCCODE + concat.trim() + pickpacknumber + concat.trim() + DOCLINE;// + concat.trim()  + CHILDNAME;*/
    userFolder = pickpacknumber;
    /*alert(userFolder)*/
    if (pickpack == "") {
        notify('error', 'Error Message', "Enter Pick Pack Number.");
    }
    else {
        $.ajax({
            type: 'GET',
            url: '/Common/GetAccInfo',
            dataType: "json",
            success: function (data) {
              //  alert('login')
                var requestData = {
                    userid: data.result[0].userid,
                    password: data.result[0].password,
                    devicedetails: data.result[0].devicedetails,
                    channel: data.result[0].channel
                };


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: data.loginUrl,
                    data: JSON.stringify(requestData),
                    dataType: "json",
                    success: function (response) {

                        const authorizationToken = 'Bearer ' + response.token;
                        var apiUrl = data.uploadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password + "&userFolder=" + userFolder.trim();

                        const fileInput = document.getElementById("fileInput" + DOCLINE);
                        
                      
                        const selectedFiles = fileInput.files;
                       
                        if (selectedFiles.length === 0) {
                            return;
                        }
                        else {

                            var formdata = new FormData();
                            for (let i = 0; i < selectedFiles.length; i++) {

                                formdata.append("formFiles", selectedFiles[i]);
                            }

                            $('#fileInput' + DOCLINE).val('');
                            /*formdata.append("ProcessID", NUMBER);*/
                            formdata.append("ProcessID", DOCLINE);        //as docline
                            formdata.append("Processcode", DOCHEADER);   //as docheader
                            formdata.append("ProcessName", pickpacknumber);  //as pickpack number

                            $.ajax({
                                url: apiUrl,
                                type: 'POST',
                                headers: {
                                    'Authorization': authorizationToken
                                },

                                data: formdata,
                                contentType: false,
                                processData: false,
                                success: function (result) {
                                  //  alert('sus')
                                    if (result.code == 200) {
                                        notify('success', 'success Message', "File Uploaded Successfully.");
                                        $.ajax({
                                            url: "/Common/FileUpload",
                                            type: 'POST',
                                            data: formdata,
                                            processData: false,
                                            contentType: false,
                                            success: function (response) {
                                                $("#disfileupload" + DOCLINE).hide();
                                                $("#fileInput" + DOCLINE).hide();
                                                $("#status" + DOCLINE).text("Complete");
                                            }
                                        });
                                    }
                                    else {
                                        notify('error', 'error Message', "Unable to Upload File.");
                                    }
                                }
                            });
                        }
                    }
                });
            }
        });
    }
    
}


function ViewImageFromAPIForDocument(ID, PROCESSCODE, PICKPACKNUMBER, pickingpackingheaderid, STATUS) {
    console.log();

    let NUMBER = PROCESSCODE.match(/\d+/g);
    let ALPHA = PROCESSCODE.replace(/[0-9]/g, '');


    let concat = "/";
    userFolder = ALPHA.trim() + concat.trim() + PICKPACKNUMBER;


    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {

            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                    const authorizationToken = 'Bearer ' + response.token;

                            var apiUrl = data.downloadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password +
                                "&userFolder=" + userFolder;

                            $.ajax({
                                url: apiUrl,
                                type: 'GET',
                                headers: {
                                    'Authorization': authorizationToken,
                                    'Content-Type': 'application/json',
                                },
                                contentType: false,
                                processData: false,
                                success: function (result) {
                                   
                                           
                                            //$scope.detailsdata = result;
                                            var apiUrl = data.downloadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password +
                                                "&userFolder=" + userFolder;

                                            $.ajax({
                                                url: apiUrl,
                                                type: 'GET',
                                                headers: {
                                                    'Authorization': authorizationToken,
                                                    'Content-Type': 'application/json',
                                                },
                                                contentType: false,
                                                processData: false,
                                                success: function (result) {
                                                  
                                                    
                                                    $.ajax({
                                                        url: "/DocumentLanding/EditbyDetailsID",
                                                        type: 'GET',
                                                        data: { id: ID, pickpackid: pickingpackingheaderid, status: STATUS },
                                                        success: function (resultdb) {
                                                            console.log(resultdb);

                                                            var html = "";
                                                            var extension = "";
                                                            var filefiting;
                                                            var k = 0;
                                                            for (var i = 0; i < resultdb.length; i++) {
                                                                    var slno = 1;
                                                                    //extension = resultdb[i].filename;
                                                                    var slno = i + 1;

                                                                if (resultdb[i].type === 'M')
                                                                    filefiting = 'Manual';
                                                                else if (resultdb[i].type === 'A')
                                                                    filefiting = 'Auto';

                                                                if (resultdb[i].docstatus === 'N') {
                                                                    extension = result.base64FileResponse[k].fileName;
                                                                    html += '<tr>';
                                                                    html += '<td>' + parseInt(slno) + '</td>';
                                                                    html += '<td>' + resultdb[i].childdocname + '</td>';
                                                                    html += '<td>' + resultdb[i].filename  + '</td>';
                                                                    html += '<td>' + resultdb[i].mandatorylabel + '</td>';
                                                                    html += '<td>' + filefiting + '</td>';
                                                                    html += '<td><span class="badge rounded-pill badge-soft-primary font-size-11">Complete</span></td>';
                                                                    //html += "<td><a  href='data:'" + extension + "';base64," + result.base64FileResponse[i].base64Content + "' download> Download</a></td>";
                                                                    html += "<td><button type='button' class='btn btn-primary btn-sm insert' onclick='Download(\"" + result.base64FileResponse[k].fileName + "\",\"" + result.base64FileResponse[k].base64Content + "\",\"" + extension + "\")'><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                                                    //html += '<td><button type="button" class="btn btn-primary btn-sm insert" onclick="Download()"><span class="fas fa-arrow-circle-down"></span> Download</button></td>';
                                                                    html += '</tr>';
                                                                    k++;
                                                                }
                                                                else {
                                                                    extension = resultdb[i].filename;
                                                                    html += '<tr>';
                                                                    html += '<td>' + parseInt(slno) + '</td>';
                                                                    html += '<td>' + resultdb[i].childdocname + '</td>';
                                                                    html += '<td>' + resultdb[i].filename  + '</td>';
                                                                    html += '<td>' + resultdb[i].mandatorylabel + '</td>';
                                                                    html += '<td>' + filefiting + '</td>';
                                                                    html += '<td><span class="badge rounded-pill badge-soft-info font-size-11">Pending</span></td>';
                                                                    html += "<td><button type='button' class='btn btn-primary btn-sm insert' disabled><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                                                    //html += "<td><button type='button' class='btn btn-primary btn-sm insert' disabled><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                                                    html += '</tr>';
                                                                   
                                                                }
                                                            }
                                                            $("#tblData").append(html);
                                                            
                                                        }
                                                    });
                                                    
                                                }
                                            });
                                        }
                                    });
                }
            });
        }
    });
}


function ShowPopUp(id, rooturl, folder) {
  //  alert(rooturl)
    var enroll = 545065;
    /* var url = rooturl + folder + "&enroll=" + enroll + "&rs:Embed=true&rc:LinkTarget=_self";*/
    var url = rooturl + folder + "&rs:Embed=true";
    //var url = "http://10.35.117.135/ReportServer/Pages/ReportViewer.aspx?/TREASURY/new/BENEFICIARY_CERTIFICATE_OF_ORIGIN&rs:Embed=true";
    var base_url = window.location.origin;
    newwindow = window.open(url, "/DocumentLanding/Print?id=" + id, 'scrollbars=yes,toolbar=0,height=400,width=800,top=70,left=50');
    if (window.focus) { newwindow.focus() }

    //var myWindow = window.open(base_url + "/DocumentLanding/Print?id=" + id + '&ysnUploder=' + ysnUpload, 'myWindow', "width=700, height=800");
    //var myWindow = window.open(base_url + "/DocumentLanding/Print?id=" + id + 'myWindow', "width=700, target=_self, height=800");
}

function loadIframe(iframeName, url) {
    var $iframe = $('#' + iframeName);
    if ($iframe.length) {
        $iframe.attr('src', url);
        return false;
    }
    return true;
}

function ViewFileFromAPI(PROCESSCODE) {

    /*let ALPHA = PROCESSCODE.substring(0, 2);*/
    userFolder = PROCESSCODE;
   // alert(userFolder)
    $.ajax({
        type: 'GET',
        url: '/Common/GetAccInfo',
        dataType: "json",
        success: function (data) {
            // alert('result')
            var requestData = {
                userid: data.result[0].userid,
                password: data.result[0].password,
                devicedetails: data.result[0].devicedetails,
                channel: data.result[0].channel
            };


            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: data.loginUrl,
                data: JSON.stringify(requestData),
                dataType: "json",
                success: function (response) {
                  //   alert('login')
                    const authorizationToken = 'Bearer ' + response.token;

                    var apiUrl = data.downloadMultiple + "?userid=" + data.result[0].userid + "&password=" + data.result[0].password +
                        "&userFolder=" + userFolder;
                   //  alert(userFolder)

                    $.ajax({
                        url: apiUrl,
                        type: 'GET',
                        headers: {
                            'Authorization': authorizationToken,
                            'Content-Type': 'application/json',
                        },
                        contentType: false,
                        processData: false,
                        success: function (result) {
                            //alert(result.base64FileResponse[0].fileName)
                            var html = "";
                            var extension = "";
                            var slno = 1;

                            for (var i = 0; i < result.base64FileResponse.length; i++) {
                                extension = result.base64FileResponse[i].fileName.split('.').pop();

                                var slno = i + 1;

                                html += '<tr>';
                                html += '<td>' + parseInt(slno) + '</td>';
                                html += '<td>' + result.base64FileResponse[i].fileName + '</td>';
                                //html += "<td><a  href='data:'" + extension + "';base64," + result.base64FileResponse[i].base64Content + "' download> Download</a></td>";
                                html += "<td><button type='button' class='btn btn-primary btn-sm insert' onclick='Download(\"" + result.base64FileResponse[i].fileName + "\",\"" + result.base64FileResponse[i].base64Content + "\",\"" + extension + "\")'><span class='fas fa-arrow-circle-down'></span> Download</button></td>";
                                //html += '<td><button type="button" class="btn btn-primary btn-sm insert" onclick="Download()"><span class="fas fa-arrow-circle-down"></span> Download</button></td>';
                                html += '</tr>';
                            }
                            $("#tblData").empty().append(html);
                            // $("#tblData").append(html);
                        }
                    });
                }
            });
        }
    });
}
function Email(NAME, TYPE, APPTYPE) {
    NAME = NAME.split(':')[1].trim();    
    NAME = NAME.replace(/[\s"]/g, '');
   // alert(NAME)
    $.ajax({
        type: 'GET', 
        url: '/Common/Email', 
        data: { name: NAME, apptype: APPTYPE, type: TYPE }, 
        dataType: "json", 
        success: function (data) {
            console.log(data);
            var no = data[0].no;
            var amount = data[0].amount;
            var rate = data[0].currencyrate;
            var totalamount = data[0].totalamount;
            var date = data[0].documentcreateddate;
            var employeename = data[0].empname;
            var typename = data[0].typename;

            if (APPTYPE = 1) {
                var emailbody = `<!DOCTYPE html>
                <html>
                <head>
                <style>
                p {
                    font-family: Century Gothic;
                    border-collapse: collapse;
                    width: 100%;
                }

                table {
                    font-family: Century Gothic;
                    border-collapse: collapse;
                    width: 100%;
                }

                td, th {
                    border: 1px solid #dddddd;
                    text-align: left;
                    padding: 8px;
                }

                tr:nth-child(even) {
                    background-color: #dddddd;
                }
                </style>
                </head>
                <body>

                <h2>REQUEST SUBMITTED: ${no}</h2>
                <p><b>Dear Concern,</b></p>

                <p>A  <b>Request No: ${no}</b> has been created for your approval pending. Please approve it for the next course of actions, or ignore it if you are not the right concern.</p><br/>

                <p><b> Request Details:</b></p>

                <table>
                <tr>
                <th> Request No:</th>
                <td>${no}</td>
                </tr> 
                <tr>
                <td> Request Type:</td>
                <td>${typename}</td>
                </tr>
                <tr>
                <td>Amount</td>
                <td>${amount}</td>
                </tr>
                <tr>
                <td>Currency Conversion Rate</td>
                <td>${rate}</td>
                </tr>
                <tr>
                <td>Total Amount (BDT)</td>
                <td>${totalamount}</td>
                </tr>
                <tr>
                <td>Created Date</td>
                <td>${date}</td>
                </tr>
                </table>

                <br />
                <p><b>Thanks,<br />  ${employeename}</b></p><br />

                </body>
                </html>`;
            }
            else {

                if (TYPE = 1) {
                        var emailbody = `<!DOCTYPE html>
                    <html>
                    <head>
                    <style>
                    p {
                        font-family: Century Gothic;
                        border-collapse: collapse;
                        width: 100%;
                    }

                    table {
                        font-family: Century Gothic;
                        border-collapse: collapse;
                        width: 100%;
                    }

                    td, th {
                        border: 1px solid #dddddd;
                        text-align: left;
                        padding: 8px;
                    }

                    tr:nth-child(even) {
                        background-color: #dddddd;
                    }
                    </style>
                    </head>
                    <body>

                    <h2>REQUEST SUBMITTED: ${no}</h2>
                    <p><b>Dear Concern,</b></p>

                       <p>A  <b>Request No: ${no}</b> has been created for your approval pending. Please approve it for the next course of actions, or ignore it if you are not the right concern.</p><br/>

                    <p><b> Request Details:</b></p>

                    <table>
                    <tr>
                    <th> Request No:</th>
                    <td>${no}</td>
                    </tr>
                    <tr>
                    <td> Request Type:</td>
                    <td>${typename}</td>
                    </tr>
                    <tr>
                    <td>Amount</td>
                    <td>${amount}</td>
                    </tr>
                    <tr>
                    <td>Currency Conversion Rate</td>
                    <td>${rate}</td>
                    </tr>
                    <tr>
                    <td>Total Amount (BDT)</td>
                    <td>${totalamount}</td>
                    </tr>
                    <tr>
                    <td>Created Date</td>
                    <td>${date}</td>
                    </tr>
                    </table>

                    <br />
                    <p><b>Thanks,<br />  ${employeename}</b></p><br />

                    </body>
                    </html>`;
                }
                else {
                    var emailbody = `<!DOCTYPE html>
                    <html>
                    <head>
                    <style>
                    p {
                        font-family: Century Gothic;
                        border-collapse: collapse;
                        width: 100%;
                    }

                    table {
                        font-family: Century Gothic;
                        border-collapse: collapse;
                        width: 100%;
                    }

                    td, th {
                        border: 1px solid #dddddd;
                        text-align: left;
                        padding: 8px;
                    }

                    tr:nth-child(even) {
                        background-color: #dddddd;
                    }
                    </style>
                    </head>
                    <body>

                    <h2>REQUEST SUBMITTED: ${no}</h2>
                    <p><b>Dear Concern,</b></p>

                    <p>A  <b>Request No: ${no}</b> has been  approved. Please take the necessary steps, if required.</p><br/>

                    <p><b> Request Details:</b></p>

                    <table>
                    <tr>
                    <th> Request No:</th>
                    <td>${no}</td>
                    </tr>
                    <tr>
                    <td> Request Type:</td>
                    <td>${typename}</td>
                    </tr>
                    <tr>
                    <td>Amount</td>
                    <td>${amount}</td>
                    </tr>
                    <tr>
                    <td>Currency Conversion Rate</td>
                    <td>${rate}</td>
                    </tr>
                    <tr>
                    <td>Total Amount (BDT)</td>
                    <td>${totalamount}</td>
                    </tr>
                    <tr>
                    <td>Created Date</td>
                    <td>${date}</td>
                    </tr>
                    </table>

                    <br />
                    <p><b>Thanks,<br />  ${employeename}</b></p><br />

                    </body>
                    </html>`;
                }
                
            }

            if (typename == "Landed Cost Management") {
                $.ajax({
                    type: 'POST',
                    url: '/Common/SendEmail',
                    data: { type: 2, apptype: APPTYPE, value: emailbody },
                    dataType: "json",
                    success: function (data) {


                    },
                    error: function (error) {

                        console.log('Error:', error);
                    }
                });
            }
            else {
                $.ajax({
                    type: 'POST',
                    url: '/Common/SendEmail',
                    data: { type: 1, apptype: APPTYPE, value: emailbody },
                    dataType: "json",
                    success: function (data) {


                    },
                    error: function (error) {

                        console.log('Error:', error);
                    }
                });
            }

            
        },
        error: function (error) {
           
            console.log('Error:', error);
        }
    });
}

