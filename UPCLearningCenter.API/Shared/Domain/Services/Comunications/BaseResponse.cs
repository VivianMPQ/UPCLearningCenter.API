﻿namespace UPCLearningCenter.API.Shared.Domain.Services.Comunications;

//tiene que ser abstracta porque es generica
public abstract class BaseResponse <T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Resource { get; set; }

    protected BaseResponse(string message) {
        Success = false;
        Message = message;
        Resource = default;
    }

    protected BaseResponse(T resource) {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    /*public IActionResult ToResponse<TResponse>(ControllerBase controller, IMapper mapper) {
        if (!Success || Resource is null) {
            return controller.BadRequest(Message);
        }

        var mapped = mapper.Map<T, TResponse>(Resource);
        return controller.Ok(mapped);
    }*/
}