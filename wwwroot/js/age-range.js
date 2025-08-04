(function($){
  $.validator.addMethod("agerange", function(val, element, params){
    if (!val) return true; // Let required handle empty values

    // Parse date and calculate age
    var dob = new Date(val);
    var today = new Date();
    var age = today.getFullYear() - dob.getFullYear();
    
    // Adjust age if birthday hasn't happened yet this year
    if (today.getMonth() < dob.getMonth() || 
        (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())) {
      age--;
    }
    
    // Check if age is within the valid range
    return age >= params.min && age <= params.max;
  });
  
  $.validator.unobtrusive.adapters.add(
    "agerange", ["min", "max"], function(options){
      options.rules["agerange"] = { 
        min: parseInt(options.params.min), 
        max: parseInt(options.params.max) 
      };
      options.messages["agerange"] = options.message;
    }
  );
})(jQuery);
